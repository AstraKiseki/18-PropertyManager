using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using PropertyManager.Api.Domain;
using PropertyManager.Api.Models;
using System.Web.Http.Cors;

namespace PropertyManager.Api
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
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            CreateMaps();
        }

        private static void CreateMaps()
        {
            Mapper.CreateMap<Property, PropertyModel>();
            Mapper.CreateMap<Address, AddressModel>();
            Mapper.CreateMap<Lease, LeaseModel>();
            Mapper.CreateMap<Tenant, TenantModel>();
            Mapper.CreateMap<WorkOrder, WorkOrderModel>();
        }
    }
    }
