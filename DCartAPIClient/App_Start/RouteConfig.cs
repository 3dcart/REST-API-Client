// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Microsoft">
//   Copyright © 2016 Microsoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.DCartAPIClient
{
    using System.Web.Routing;
    using System.Web.Http;
    using App.DCartAPIClient.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapHttpRoute(
            //    name: "Controller only",
            //    routeTemplate: "{controller}"
            //    );

            routes.MapHttpRoute(
                name: "Controller only",
                routeTemplate: "{controller}/{ClientType}/{action}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
                );

            routes.Add("Default", new DefaultRoute());

        }
    }
}
