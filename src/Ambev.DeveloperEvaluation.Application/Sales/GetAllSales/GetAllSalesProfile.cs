﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesProfile : Profile
    {
        public GetAllSalesProfile() 
        {
            CreateMap<Sale, SaleSummaryDto>()
                .ForMember(dest => dest.ItemsCount, opt => opt.MapFrom(src => src.Items.Count(i => !i.IsCancelled)));
        }
    }
}
