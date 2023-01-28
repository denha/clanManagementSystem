using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClanManagement.BusinessLogic.Data.Dto;
using ClanManagement.BusinessLogic.Data.Models;

namespace ClanManagement.BusinessLogic.Data.AutoMapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GetClanMottoDto, ClanMotto>().ReverseMap();
            CreateMap<GetLanguageDto, Language>().ReverseMap();
            CreateMap<GetNameDto, Name>().ReverseMap();
            //CreateMap<UpdateLanguageDto,L>
        }
    }
}
