using AutoMapper;
using ClimateChangeIndicators.App.ViewModels;
using ClimateChangeIndicators.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeIndicators.App.Profiles
{
    public class IndicatorsProfiles : Profile
    {
        public IndicatorsProfiles()
        {
            CreateMap<Indicator, IndicatorViewModel>()
                .ForMember(vm => vm.Organization, o => o.MapFrom(i => i.Owner.Organization.Name))
                .ForMember(vm => vm.Department, o => o.MapFrom(i => i.Owner.Branch!.Department.Name))
                .ForMember(vm => vm.Branch, o => o.MapFrom(i => i.Owner.Branch!.Name));

        }
    }
}
