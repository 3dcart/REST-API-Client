using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDCart.Core.Models
{
    public class Product
    {
        public Skuinfo SKUInfo { get; set; }
        //public string MFGID { get; set; }
        //public string ShortDescription { get; set; }
        //public int ManufacturerID { get; set; }
        //public string ManufacturerName { get; set; }
        //public object[] DistributorList { get; set; }
        //public DateTime LastUpdate { get; set; }
        //public object UserID { get; set; }
        //public string GTIN { get; set; }
        //public Categorylist[] CategoryList { get; set; }
        //public object[] ExternalIdsList { get; set; }
        //public object[] CategoryExternalIdsList { get; set; }
        //public bool NonTaxable { get; set; }
        //public bool NotForSale { get; set; }
        //public bool Hide { get; set; }
        //public bool GiftCertificate { get; set; }
        //public bool HomeSpecial { get; set; }
        //public bool CategorySpecial { get; set; }
        //public bool NonSearchable { get; set; }
        //public bool GiftWrapItem { get; set; }
        //public float ShipCost { get; set; }
        //public float Weight { get; set; }
        //public float Height { get; set; }
        //public float Width { get; set; }
        //public float Depth { get; set; }
        //public bool SelfShip { get; set; }
        //public bool FreeShipping { get; set; }
        //public int RewardPoints { get; set; }
        //public int RedeemPoints { get; set; }
        //public bool DisableRewards { get; set; }
        //public int StockAlert { get; set; }
        //public int ReorderQuantity { get; set; }
        //public string InStockMessage { get; set; }
        //public string OutOfStockMessage { get; set; }
        //public string BackOrderMessage { get; set; }
        //public int InventoryControl { get; set; }
        //public string WarehouseLocation { get; set; }
        //public string WarehouseBin { get; set; }
        //public string WarehouseAisle { get; set; }
        //public string WarehouseCustom { get; set; }
        //public string Description { get; set; }
        //public string Keywords { get; set; }
        //public string ExtraField1 { get; set; }
        //public string ExtraField2 { get; set; }
        //public string ExtraField3 { get; set; }
        //public string ExtraField4 { get; set; }
        //public string ExtraField5 { get; set; }
        //public string ExtraField6 { get; set; }
        //public string ExtraField7 { get; set; }
        //public string ExtraField8 { get; set; }
        //public string ExtraField9 { get; set; }
        //public string ExtraField10 { get; set; }
        //public string ExtraField11 { get; set; }
        //public string ExtraField12 { get; set; }
        //public string ExtraField13 { get; set; }
        //public object[] FeatureList { get; set; }
        //public Pluginlist PluginList { get; set; }
        //public bool SampleEnable { get; set; }
        //public string SampleName { get; set; }
        //public string SampleSKUPrefix { get; set; }
        //public float SamplePrice { get; set; }
        //public float SampleWeight { get; set; }
        //public float ReviewAverage { get; set; }
        //public int ReviewCount { get; set; }
        //public string MainImageFile { get; set; }
        //public string MainImageCaption { get; set; }
        //public string ThumbnailFile { get; set; }
        //public string MediaFile { get; set; }
        //public string AdditionalImageFile2 { get; set; }
        //public string AdditionalImageCaption2 { get; set; }
        //public string AdditionalImageFile3 { get; set; }
        //public string AdditionalImageCaption3 { get; set; }
        //public string AdditionalImageFile4 { get; set; }
        //public string AdditionalImageCaption4 { get; set; }
        //public Imagegallerylist[] ImageGalleryList { get; set; }
        //public Optionsetlist[] OptionSetList { get; set; }
        //public object[] AdvancedOptionList { get; set; }
        //public Relatedproductlist[] RelatedProductList { get; set; }
        //public Upsellingitemlist[] UpSellingItemList { get; set; }
        //public Discountlist[] DiscountList { get; set; }
        //public bool DoNotUseCategoryOptions { get; set; }
        //public DateTime DateCreated { get; set; }
        //public int ListingTemplateID { get; set; }
        //public string ListingTemplateName { get; set; }
        //public int LoginRequiredOptionID { get; set; }
        //public string LoginRequiredOptionName { get; set; }
        //public string LoginRequiredOptionRedirectTo { get; set; }
        //public object AllowAccessCustomerGroupID { get; set; }
        //public object AllowAccessCustomerGroupName { get; set; }
        //public string RMAMaxPeriod { get; set; }
        //public string CanonicalUrl { get; set; }
        //public string TaxCode { get; set; }
        //public string DisplayText { get; set; }
        //public float MinimumQuantity { get; set; }
        //public float MaximumQuantity { get; set; }
        //public bool AllowOnlyMultiples { get; set; }
        //public bool AllowFractionalQuantity { get; set; }
        //public string QuantityOptions { get; set; }
        //public bool GroupOptionsForQuantityPricing { get; set; }
        //public bool ApplyQuantityDiscountToOptions { get; set; }
        //public bool EnableMakeAnOfferFeature { get; set; }
        //public string MinimumAcceptableOffer { get; set; }
        //public float PriceLevel1 { get; set; }
        //public bool PriceLevel1Hide { get; set; }
        //public float PriceLevel2 { get; set; }
        //public bool PriceLevel2Hide { get; set; }
        //public float PriceLevel3 { get; set; }
        //public bool PriceLevel3Hide { get; set; }
        //public float PriceLevel4 { get; set; }
        //public bool PriceLevel4Hide { get; set; }
        //public float PriceLevel5 { get; set; }
        //public bool PriceLevel5Hide { get; set; }
        //public float PriceLevel6 { get; set; }
        //public bool PriceLevel6Hide { get; set; }
        //public float PriceLevel7 { get; set; }
        //public bool PriceLevel7Hide { get; set; }
        //public float PriceLevel8 { get; set; }
        //public bool PriceLevel8Hide { get; set; }
        //public float PriceLevel9 { get; set; }
        //public bool PriceLevel9Hide { get; set; }
        //public float PriceLevel10 { get; set; }
        //public bool PriceLevel10Hide { get; set; }
        //public string BuyButtonLink { get; set; }
        //public string ProductLink { get; set; }
        //public string Title { get; set; }
        //public string CustomFileName { get; set; }
        //public string RedirectLink { get; set; }
        //public string MetaTags { get; set; }
        //public string SpecialInstructions { get; set; }
        //public bool AssignKey { get; set; }
        //public bool ReUseKeys { get; set; }
        //public object[] SerialList { get; set; }
        //public object[] EProductList { get; set; }
    }

    public class Skuinfo
    {
        public int CatalogID { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public string RetailPrice { get; set; }
        public string SalePrice { get; set; }
        public bool? OnSale { get; set; }
        public int Stock { get; set; }
    }

    public class Pluginlist
    {
    }

    public class Categorylist
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class Imagegallerylist
    {
        public int ImageGalleryID { get; set; }
        public string ImageGalleryFile { get; set; }
        public string ImageGalleryCaption { get; set; }
        public int ImageGallerySorting { get; set; }
    }

    public class Optionsetlist
    {
        public int OptionSetID { get; set; }
        public string OptionSetName { get; set; }
        public float OptionSorting { get; set; }
        public bool OptionRequired { get; set; }
        public string OptionType { get; set; }
        public string OptionURL { get; set; }
        public string OptionAdditionalInformation { get; set; }
        public int OptionSizeLimit { get; set; }
        public Optionlist[] OptionList { get; set; }
    }

    public class Optionlist
    {
        public int OptionID { get; set; }
        public string OptionName { get; set; }
        public bool OptionSelected { get; set; }
        public bool OptionHide { get; set; }
        public float OptionValue { get; set; }
        public string OptionPartNumber { get; set; }
        public float OptionSorting { get; set; }
        public string OptionImagePath { get; set; }
        public int OptionBundleCatalogId { get; set; }
        public int OptionBundleQuantity { get; set; }
    }

    public class Relatedproductlist
    {
        public int RelatedIndexID { get; set; }
        public int RelatedProductID { get; set; }
        public int RelatedProductSorting { get; set; }
    }

    public class Upsellingitemlist
    {
        public int UpSellingIndexID { get; set; }
        public int UpSellingItemID { get; set; }
        public int UpSellingItemSorting { get; set; }
    }

    public class Discountlist
    {
        public int DiscountID { get; set; }
        public int DiscountPriceLevel { get; set; }
        public int DiscountLowbound { get; set; }
        public int DiscountUpbound { get; set; }
        public float DiscountPrice { get; set; }
        public bool DiscountPercentage { get; set; }
    }
}
