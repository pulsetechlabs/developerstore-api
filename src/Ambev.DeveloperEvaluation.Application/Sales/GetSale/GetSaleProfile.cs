using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleProfile : Profile
    { 
        public GetSaleProfile() 
        {
            CreateMap<Sale, GetSaleResult>();
            CreateMap<SaleItem, SaleItemDto>();
        }
    }
}
