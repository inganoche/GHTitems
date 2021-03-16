using AutoMapper;
using GHT.Core.DTOs;
using GHT.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHT.Domine.Mappings
{
    public class AutomapperProfile: Profile
    {

        public AutomapperProfile()
        {
            CreateMap<Buys, BuysDto>();
            CreateMap<BuysDto, Buys>();


            CreateMap<Buys, BuysDtoOut>().ForMember(d => d.nombreItem, opt => opt.MapFrom(x => x.Items.nameItems));
               

        }

    }
}
