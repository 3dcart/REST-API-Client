using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DCartRestAPIClient
{

    public class Category : IRestAPIType
    {
        #region Category
            public int? CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Link { get; set; }
            public string CategoryDescription  { get; set; }
            public string CategoryIcon { get; set; }
            public bool? CategoryMain { get; set; }
            public int? CategoryParent { get; set; }
            public int? Sorting { get; set; }
            public bool? Hide { get; set; }
            public string UserID { get; set; }
            public DateTime? LastUpdate { get; set; }
            public int? CategoryMenuGroup { get; set; }
            public bool? HomeSpecialCategory { get; set; }
            public bool? FilterCategory { get; set; }
        #endregion

        #region Category Page Settings
            public int? TemplateCategoryPage { get; set; }
            public int? DefaultProductsSorting { get; set; }
            public int? SubcategoryColumnsCategorySpecials { get; set; }
            public int? ProductColumnsCategorySpecials { get; set; }
            public int? ProductColumnsCategoryGeneralItems { get; set; }
            public int? ItemsPerPageCategorySpecialItems { get; set; }
            public int? ItemsPerPageCategoryGeneralItems { get; set; }
            public int? DisplayTypeCategorySpecialItems { get; set; }
            public int? DisplayTypeCategoryGeneralProducts { get; set; }
            public string AllowAccess { get; set; }
            public string OnFailRedirectTo { get; set; }
            public bool? HideLeftBar { get; set; }
            public bool? HideRightBar { get; set; }
            public bool? HideTopMenu { get; set; }
        #endregion

        #region SmartCategories
            public int? SmartCategories { get; set; }
            public string SmartCategoriesSearchKeyword { get; set; }
            public string SmartCategoriesLinkTarget { get; set; }
        #endregion

        #region Product Display
            public int? TemplateProductPage { get; set; }
            public int? ProductColumnsRelatedProducts { get; set; }
            public int? ProductColumnsUpsellProducts { get; set; }
            public int? DisplayTypeRelatedItems { get; set; }
            public int? DisplayTypeUpsellItems { get; set; }
            public List<OptionSet> OptionSetList { get; set; }
        #endregion

        #region SEO Title & Meta tags
            public string Title { get; set; }
            public string CustomFileName { get; set; }
            public string MetaTags { get; set; }
        #endregion

        #region Page Content
            public string CategoryHeader { get; set; }
            public string CategoryFooter { get; set; }
            public string AdditionalKeywords { get; set; }
        #endregion

            public static RestAPIType key
            {
                get
                {
                    return RestAPIType.Category;
                }
            }

            public static string Type
            {
                get
                {
                    return "Categories";
                }
            }

    }

  
}