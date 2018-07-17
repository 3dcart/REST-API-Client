using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using ThreeDCart.Core.Models;
using System.Linq;
using System.Net;

namespace ThreeDCart.Core
{
    public class ThreeDCartProvider
    {
        ThreeDCartJsonParser parser;

        public ThreeDCartProvider(string privateKey, string token, string secureUrl)
        {
            parser = new ThreeDCartJsonParser(privateKey, token, secureUrl);
        }

        public List<Category> SearchCategories()
        {
            List<Category> categories = new List<Category>();
            string baseUrl = "https://apirest.3dcart.com/3dCartWebAPI/v1/Categories?";
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["limit"] = "1";
            return parser.GetJson<List<Category>>(baseUrl + queryString.ToString(), null);
        }

        public List<Order> SearchOrdersByNumber(string number)
        {
            List<Order> orders = new List<Order>();
            string url = "https://apirest.3dcart.com/3dCartWebAPI/v1/Orders/" + number;
            return parser.GetJson<List<Order>>(url, null);
        }

        public List<Order> SearchOrders(DateTime beginDate, DateTime endDate, string orderStatus)
        {
            List<Order> orders = new List<Order>();

            string baseUrl = "https://apirest.3dcart.com/3dCartWebAPI/v1/Orders?";
            int limit = 100;

            for (int i = 1; i < 10; i++)
            {
                NameValueCollection queryString = GetQueryStringForSearchOrders(beginDate, endDate, orderStatus, limit, i);

                string url = baseUrl + queryString.ToString();

                List<Order> newOrders = new List<Order>();

                try
                {
                    newOrders = parser.GetJson<List<Order>>(url, null);
                }
                catch (WebException we)
                {
                    HttpWebResponse errorResponse = we.Response as HttpWebResponse;
                    if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        
                    }
                    else
                    {
                        throw;
                    }
                }

                orders.AddRange(newOrders);

                if (newOrders.Count < 99)
                    break;
            }

            return orders;
        }

        public Dictionary<int, string> GetOrderStatuses()
        {
            Dictionary<int, string> statuses = new Dictionary<int, string>();

            statuses.Add(1, "New");
            statuses.Add(2, "Processing");
            statuses.Add(3, "Partial");
            statuses.Add(4, "Shipped");
            statuses.Add(5, "Cancel");
            statuses.Add(6, "Hold");
            statuses.Add(11, "Unpaid");

            return statuses;
        }

        private int GetOrderStatusFromPhrase(string phrase)
        {
            Dictionary<int, string> statuses = GetOrderStatuses();

            return statuses.Where(a => a.Value == phrase).FirstOrDefault().Key;
        }

        private NameValueCollection GetQueryStringForSearchOrders(DateTime beginDate, DateTime endDate, string orderStatus, int limit, int i)
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            if (!String.IsNullOrEmpty(orderStatus))
            {
                queryString["lastupdatestart"] = beginDate.ToUniversalTime().ToString();
                queryString["lastupdateend"] = endDate.ToUniversalTime().ToString();
                queryString["orderstatus"] = GetOrderStatusFromPhrase(orderStatus).ToString();
            }
            else
            {
                queryString["datestart"] = beginDate.ToUniversalTime().ToString();
                queryString["dateend"] = endDate.ToUniversalTime().ToString();
            }

            queryString["limit"] = limit.ToString();
            queryString["offset"] = i.ToString();
            return queryString;
        }

        public List<Product> SearchProducts(string sku)
        {
            string url = "https://apirest.3dcart.com/3dCartWebAPI/v1/Products?sku=" + sku;
            return parser.GetJson<List<Product>>(url, null);
        }


        public List<ThreeDCartUpdateProductResponse> UpdateProduct(List<Skuinfo> skus)
        {
            List<ThreeDCartUpdateProductResponse> responses = new List<ThreeDCartUpdateProductResponse>();

            List<Product> datas = GetProductsToSync(skus);

            if (datas.Count == 0)
                return responses;

            string url = "https://apirest.3dcart.com/3dCartWebAPI/v1/Products?";

            string postString = JsonConvert.SerializeObject(datas, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            responses = parser.PostPutJson<List<ThreeDCartUpdateProductResponse>>(url, postString, null, "PUT");

            AssignProductSkusToResponses(responses, datas);

            return responses;
        }

        private void AssignProductSkusToResponses(List<ThreeDCartUpdateProductResponse> responses, List<Product> datas)
        {
            foreach (ThreeDCartUpdateProductResponse response in responses)
            {
                Product pr = datas.Where(a => a.SKUInfo.CatalogID.ToString() == response.Value).FirstOrDefault();

                if (pr != null)
                    response.Sku = pr.SKUInfo.SKU;
            }
        }

        private List<Product> GetProductsToSync(List<Skuinfo> skus)
        {
            List<Product> datas = new List<Product>();

            foreach (Skuinfo sku in skus)
            {
                Product existingProduct = SearchProducts(sku.SKU)[0];

                if (existingProduct == null)
                    continue;

                sku.CatalogID = existingProduct.SKUInfo.CatalogID;

                Product pr = new Product();
                pr.SKUInfo = sku;

                datas.Add(pr);
            }

            return datas;
        }
    }
}
