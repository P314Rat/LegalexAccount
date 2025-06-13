﻿using Application.Core.DTO;
using AutoMapper;
using Domain.Core.UserAggregate;


namespace Application.Core.Mappings
{
    public class ProfileMappingProfile : Profile
    {
        public ProfileMappingProfile()
        {
            CreateMap<ProfileDTO, Specialist>()
                .ForAllMembers(opt => opt
                .Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ProfileDTO, Legal>()
                .ForAllMembers(opt => opt
                .Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ProfileDTO, Person>()
                .ForAllMembers(opt => opt
                .Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Specialist, ProfileDTO>()
                .ForMember(dst => dst.Role, opt => opt.MapFrom(src => Enum.Parse(typeof(Utilities.Types.UserRole), src.Role.Name)))
                .ForMember(dst => dst.SpecialistRole, opt => opt.MapFrom(src => Enum.Parse(typeof(Utilities.Types.SpecialistRole), src.SpecialistRole.Name)));
            CreateMap<Legal, ProfileDTO>()
                .ForMember(dst => dst.Role, opt => opt.MapFrom(src => Enum.Parse(typeof(Utilities.Types.UserRole), src.Role.Name)))
                .ForMember(dst => dst.ClientRole, opt => opt.MapFrom(src => Enum.Parse(typeof(Utilities.Types.ClientRole), src.ClientRole.Name)));
            CreateMap<Person, ProfileDTO>()
                .ForMember(dst => dst.Role, opt => opt.MapFrom(src => Enum.Parse(typeof(Utilities.Types.UserRole), src.Role.Name)))
                .ForMember(dst => dst.ClientRole, opt => opt.MapFrom(src => Enum.Parse(typeof(Utilities.Types.ClientRole), src.ClientRole.Name)));
        }
    }
}
