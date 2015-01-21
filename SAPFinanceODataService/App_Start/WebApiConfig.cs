using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using SAPFinanceODataService.Models;
using System.Web.Http.OData.Extensions;

namespace SAPFinanceODataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<tbl_Solicitation_Quotes>("SolicitationQuotes");
            builder.EntitySet<tbl_Quote_Quantities>("QuoteQuantities");
            builder.EntitySet<vw_SAPFinance_Terms>("Terms");
            builder.EntitySet<vw_SAPFinance_Quotes>("Quotes");
            builder.EntitySet<vw_SAPFinance_QuoteLines>("QuoteLines");
            builder.EntitySet<vw_SAPFinance_Articles>("Articles");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
