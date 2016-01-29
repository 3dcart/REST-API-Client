using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace DCartRestAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunAsync().Wait();
            RunMethods();

        }

        static async Task RunAsync()
        {
            try
            {
                string sHost = string.Empty;
                string sPrivateKey = string.Empty;
                string sToken = string.Empty;
                string sSecureURL = string.Empty;
                string sVersion = string.Empty;
                string sContentType = string.Empty;
                string sCustomerID = string.Empty;
                string sType= string.Empty;
                string sID = string.Empty;

                bool IsCustomerGroup = false;

                //using (var client = new HttpClient())
                //{



                sHost = "http://apirest.3dcart.com/3dCartWebAPI/v";
                sVersion = "1";
                sPrivateKey = "bc6c0b6ae8d1fa40314b65fec3047c8b";
                sToken = "f244f1d222b5a691db32ff537281121f";
                sSecureURL = "https://3dcart-nadeem-com.3dcartstores.com";
                sContentType = "application/json";

                sID = "";

                HttpClient client = GetClient(sHost, sVersion, sPrivateKey, sToken, sSecureURL, sContentType);

                //HttpClient3dCart cartClass = new HttpClient3dCart();

                //SiteCustomers custClass = new SiteCustomers();

                //custClass.HttpHost = sHost;
                //custClass.ServiceVersion = sVersion;
                //custClass.PrivateKey = sPrivateKey;
                //custClass.Token = sToken;
                //custClass.SecureURL = sSecureURL;
                //custClass.ContentType = sContentType;
                //custClass.Type = "Customers";

                //HttpClient client = custClass.GetClient();


                //client.BaseAddress = new Uri(sHost + sVersion +"/");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(sContentType));

                //client.DefaultRequestHeaders.Add("privatekey", sPrivateKey);
                //client.DefaultRequestHeaders.Add("token", sToken);
                //client.DefaultRequestHeaders.Add("secureUrl", sSecureURL);

                if (IsCustomerGroup)
                {
                    sType = "CustomerGroups";
                }
                else
                {
                    sType = "Customers";
                }



                //GET

                if (sID != string.Empty)
                {
                    sType += "/" + sID;
                }

                
                HttpResponseMessage response = await client.GetAsync(sType);

                
                    
                if (response.IsSuccessStatusCode)
                {

                    List<Customer> custList = new List<Customer>();


                    //Customer customer = await JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync());

                        
                    string receiveStream = await response.Content.ReadAsStringAsync();

                    List<Customer> customerList = (List<Customer>)JsonConvert.DeserializeObject(receiveStream, typeof(List<Customer>));

                    //Console.WriteLine("{0}\t", receiveStream);
                    //Console.ReadKey();

                }

                
                //POST
                Customer cust = new Customer() { Email = "flowers@3dcart.com", Password="somepassword", BillingFirstName = "Flower", BillingLastName = "Rose" };

                response = await client.PostAsJsonAsync(sType, cust);


                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Customer Added");
                    Console.ReadKey();

                }
                


                //PUT
                Customer cust1 = new Customer() { BillingFirstName = "Mannay", BillingLastName = "Pacqino", CustomerID=7 };
                //cust.BillingFirstName = "John";
                response = await client.PutAsJsonAsync(sType, cust1);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Customer Updated");
                    //Console.ReadKey();
                }


                //DELETE
                response = await client.DeleteAsync(sType);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Customer Deleted");
                    Console.ReadKey();
                }




                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static HttpClient GetClient(string sHost, string sVersion, string sPrivateKey, string sToken, string sSecureURL, string sContentType)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(sHost + sVersion + "/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(sContentType));

            client.DefaultRequestHeaders.Add("privatekey", sPrivateKey);
            client.DefaultRequestHeaders.Add("token", sToken);
            client.DefaultRequestHeaders.Add("secureUrl", sSecureURL);

            return client;

        }

        public static string GetRestAPIType(RestAPIType restAPI)
        {
            string restAPIString = string.Empty;

            if (restAPI == RestAPIType.Customer)
            {
                restAPIString = "Customers";
            }
            else if (restAPI == RestAPIType.CustomerGroup)
            {
                restAPIString = "CustomerGroups";
            }
            else if (restAPI == RestAPIType.Order)
            {
                restAPIString = "Orders";
            }
            else if (restAPI == RestAPIType.Product)
            {
                restAPIString = "Products";
            }
            else if (restAPI == RestAPIType.Distributor)
            {
                restAPIString = "Distributors";
            }
            else if (restAPI == RestAPIType.Manufacturer)
            {
                restAPIString = "Manufacturers";
            }
            else if (restAPI == RestAPIType.Category)
            {
                restAPIString = "Categories";
            }

            return restAPIString;




        }

        public static void RunMethods()
        {
            //Initialize all variables
            string sHost = string.Empty;
            string sPrivateKey = string.Empty;
            string sToken = string.Empty;
            string sSecureURL = string.Empty;
            string sVersion = string.Empty;
            string sContentType = string.Empty;
            string sCustomerID = string.Empty;
            string sType = string.Empty;
            string sID = string.Empty;

            //Provide the parameters for the HTTP Client 
            sHost = "http://apirest.3dcart.com/3dCartWebAPI/v";
            sVersion = "1";
            sPrivateKey = "bc6c0b6ae8d1fa40314b65fec3047c8b";
            sToken = "f244f1d222b5a691db32ff537281121f";
            sSecureURL = "https://3dcart-nadeem-com.3dcartstores.com";
            sContentType = "application/json";

            //Create the instance of SitRecords class that performs HTTP GET, POST, PUT and DELETE
            RestAPIActions objectClass = new RestAPIActions();

            //For Product
            //sPrivateKey = "57f27035ea3d8aba663f9c1d55bbc3be";
            //sToken = "cfee277cd92d0d45a131dd46fd4351a3";

            //For Order
            //sPrivateKey = "0391a083cd7b6a2fc137ca63a9e1653a";
            //sToken = "0e3bee1903d00f70e6ce57f0fef245ab";

            //For Manufacturer and Distributor
            //sPrivateKey = "b3343cc81e7cd0ff31bca85cb8dbb63c";
            //sToken = "4d11264cdeb5987f6a5044f683698dc3";

            //For Category
            //sPrivateKey = "701bc75f1055f7aaef09d6f9b2479022";
            //sToken = "dea3a5e2032a408441f6248b0ba30cd4";

            //provide all the required parameters for HTTP Client
            objectClass.HttpHost = sHost;
            objectClass.ServiceVersion = sVersion;
            objectClass.PrivateKey = sPrivateKey;
            objectClass.Token = sToken;
            objectClass.SecureURL = sSecureURL;
            objectClass.ContentType = sContentType;
            
            
            //Specify the type of Rest API
            objectClass.Type = GetRestAPIType(RestAPIType.CustomerGroup);


            //GET
            
            //objectClass.ID = 2;
            CallFunctions(null, objectClass, ActionType.Get, RestAPIType.CustomerGroup);

            
            //POST

            //Customer RecordToAdd = new Customer() { Email = "letsdiscover8@3dcart.com", Password = "somepassword", BillingFirstName = "Mark", BillingLastName = "Adams" };
            CustomerGroup RecordToAdd = new CustomerGroup() { Name = "AnotherCustomerGroup121615_01", Description = "CustomerGroup121615_01" };
            CallFunctions(RecordToAdd, objectClass, ActionType.Add, RestAPIType.CustomerGroup);
            Type a = typeof(CustomerGroup);

            
            //PUT
            objectClass.ID = 2;
            //Customer RecordToUpdate = new Customer() { BillingFirstName = "Andrew", BillingLastName = "Williams", CustomerID = objectClass.ID };
            CustomerGroup RecordToUpdate = new CustomerGroup() { CustomerGroupID = objectClass.ID, Description="SupportCustomers" };
            CallFunctions(RecordToUpdate, objectClass, ActionType.Update, RestAPIType.CustomerGroup);
            

            //DELETE
            objectClass.ID = 4;
            //CallFunctions(null, objectClass, ActionType.Delete );

        }


        public static void CallFunctions(IRestAPIType singletonAPIObject, RestAPIActions siteRecords, ActionType action, RestAPIType type )
        {
            //RestAPIObject recordToProcess = null;
            //List<RestAPIObject> recordList = new List<RestAPIObject>();
            
            List<IRestAPIType> recordList = new List<IRestAPIType>();

            RestAPIClassFactory classFactory = new RestAPIClassFactory();

            

            #region Commented Code

            /*            
                        if (siteRecords.Type == GetRestAPIType(RestAPIType.Customer) )
                        {
                            recordToProcess = (Customer)singletonAPIObject;
                        }

                        if (siteRecords.Type == GetRestAPIType(RestAPIType.CustomerGroup) )
                        {
                            recordToProcess = (CustomerGroup)singletonAPIObject;
                        }


                        if (siteRecords.Type == GetRestAPIType(RestAPIType.Order) )
                        {
                            recordToProcess = (Order)singletonAPIObject;
                        }

                        if (siteRecords.Type == GetRestAPIType(RestAPIType.Product) )
                        {
                            recordToProcess = (Product)singletonAPIObject;
                        }

                        if (siteRecords.Type == GetRestAPIType(RestAPIType.Manufacturer) )
                        {
                            recordToProcess = (Manufacturer)singletonAPIObject;
                        }

                        if (siteRecords.Type == GetRestAPIType(RestAPIType.Distributor) )
                        {
                            recordToProcess = (Distributor)singletonAPIObject;
                        }

                        if (siteRecords.Type ==  GetRestAPIType(RestAPIType.Category) )
                        {
                            recordToProcess = (Category)singletonAPIObject;
                        }
            */

            #endregion

            string sIDPrefix = siteRecords.Type.Substring(0, siteRecords.Type.Length - 1) + "ID: ";


            if (action == ActionType.Get)
            {
                //GET
                RecordInfo recInf = siteRecords.GetRecords();


                if (recInf.Status == ActionStatus.Succeeded)
                {
                    Console.WriteLine("Record(s) retrieved successfully.");
                    try
                    {
                        List<Object> reclist = (List<Object>)recInf.ResultSet;

                        IRestAPIType restAPIRecord = classFactory.GetRestAPIClassType(type);


                        foreach(Object record in reclist)
                        {
                            string receiveStream = record.ToString();
                            
                            //Use the type received from function

                            restAPIRecord = (IRestAPIType)JsonConvert.DeserializeObject(receiveStream, restAPIRecord.GetType());

                            #region Commented Code
                            /*
                            if (siteRecords.Type == GetRestAPIType(RestAPIType.Customer) )
                            {
                                restAPIRecord = (Customer)JsonConvert.DeserializeObject(receiveStream, restAPIRecord.GetType());
                                //restAPIRecord = (IRestAPIType) JsonConvert.DeserializeObject(receiveStream, restAPIRecord.GetType());

                            }
                            else if (siteRecords.Type == GetRestAPIType(RestAPIType.CustomerGroup) )
                            {
                                restAPIRecord = (CustomerGroup)JsonConvert.DeserializeObject(receiveStream, restAPIRecord.GetType());
                                
                            }

                            else if (siteRecords.Type == GetRestAPIType(RestAPIType.Product) )
                            {
                                restAPIRecord = (Product)JsonConvert.DeserializeObject(receiveStream, typeof(Product));
                            }
                            else if (siteRecords.Type == GetRestAPIType(RestAPIType.Order))
                            {
                                restAPIRecord = (Order)JsonConvert.DeserializeObject(receiveStream, typeof(Order));
                            }
                            else if (siteRecords.Type == GetRestAPIType(RestAPIType.Manufacturer) )
                            {
                                restAPIRecord = (Manufacturer)JsonConvert.DeserializeObject(receiveStream, typeof(Manufacturer));
                            }
                            else if (siteRecords.Type == GetRestAPIType(RestAPIType.Distributor) )
                            {
                                restAPIRecord = (Distributor)JsonConvert.DeserializeObject(receiveStream, typeof(Distributor));
                            }
                            else if (siteRecords.Type == GetRestAPIType(RestAPIType.Category) )
                            {
                                restAPIRecord = (Category)JsonConvert.DeserializeObject(receiveStream, typeof(Category));
                            }
                            */
                            #endregion

                            recordList.Add(restAPIRecord);
                        }

                        
                    }
                    catch (Exception ex)
                    { 

                    }

                }
                else
                {
                    Console.WriteLine("Record(s) retrieval failed. Error description: " + recInf.Description);
                }

            }


            //IRestAPIType recordToProcess = classFactory.GetRestAPIClassType(type);
            

            if (action == ActionType.Add)
            {

                //POST
                //RecordInfo addInfo = siteRecords.AddRecord(recordToProcess);
                RecordInfo addInfo = siteRecords.AddRecord(singletonAPIObject);


                if (addInfo.Status == ActionStatus.Succeeded)
                {
                    Console.WriteLine("Record Added. " + sIDPrefix + addInfo.ResultSet);
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("Add failed.  Error Code: " + addInfo.CodeNumber + ", Description: " + addInfo.Description);
                    Console.ReadKey();
                }

            }


            if (action == ActionType.Update)
            {

                //PUT
                //RecordInfo updateInfo = siteRecords.UpdateRecord(recordToProcess);
                RecordInfo updateInfo = siteRecords.UpdateRecord(singletonAPIObject);
                

                if (updateInfo.Status == ActionStatus.Succeeded)
                {
                    Console.WriteLine("Record Updated. " + sIDPrefix + siteRecords.ID);
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("Update failed for " + sIDPrefix + siteRecords.ID + ". Error Code: " + updateInfo.CodeNumber + ", Description: " + updateInfo.Description);
                    Console.ReadKey();
                }

            }

            if (action == ActionType.Delete)
            {
                //DELETE
                RecordInfo deleteInfo = siteRecords.DeleteRecord();

                if (deleteInfo.Status == ActionStatus.Succeeded)
                {
                    Console.WriteLine("Record Deleted. " + sIDPrefix + "ID: " + siteRecords.ID);
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("Delete failed for " + sIDPrefix + siteRecords.ID + ". Error Code: " + deleteInfo.CodeNumber + ", Description: " + deleteInfo.Description);
                    Console.ReadKey();
                }

            }


        }


    }

    public enum ActionType : int
    {
        Get = 1,
        Add = 2,
        Update = 3,
        Delete = 4

    };


}
