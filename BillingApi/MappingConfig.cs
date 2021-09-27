using AutoMapper;
using BillingApi.Model;
using BillingApi.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<LedgerItemDto, LedgerItem>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
