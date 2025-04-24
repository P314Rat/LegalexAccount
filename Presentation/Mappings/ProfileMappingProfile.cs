using Application.Core.DTO;
using AutoMapper;
using Presentation.ViewModels;
using Presentation.ViewModels.EditProfile;
using Utilities.Types;


namespace Presentation.Mappings
{
    public class ProfileMappingProfile : Profile
    {
        public ProfileMappingProfile()
        {
            CreateMap<ProfileDTO, ClientViewModel>()
                .ForMember(dst => dst.Type,
                    opt => opt
                    .MapFrom(src =>
                        !string.IsNullOrWhiteSpace(src.OrganizationName)
                            ? ClientRole.Legal
                            : ClientRole.Person))
                .ForMember(dst => dst.Client,
                        opt => opt
                        .MapFrom(src => $"{src.FirstName} {src.LastName}")
                        )
                .ReverseMap();
            CreateMap<ProfileDTO, SpecialistViewModel>()
                .ForMember(dst => dst.Role,
                    opt => opt.MapFrom(src => src.Role))
                .ForMember(dst => dst.Employee,
                        opt => opt
                        .MapFrom(src => $"{src.FirstName} {src.LastName}")
                        )
                .ReverseMap();


            // Общий маппинг для ProfileDTO -> EditProfileViewModel
            CreateMap<ProfileDTO, EditProfileViewModel>()
                .ForMember(dest => dest.GeneralModel, opt => opt.MapFrom(src => src)) // Маппинг для GeneralModel
                .ForMember(dest => dest.OrganizationModel, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.BankAccountModel, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.DocumentsModel, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.SecurityModel, opt => opt.MapFrom(src => src));

            // Маппинг для каждого ViewModel из DTO
            CreateMap<ProfileDTO, GeneralViewModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.SurName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

            CreateMap<ProfileDTO, OrganizationViewModel>()
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.OrganizationName))
                .ForMember(dest => dest.LegalAddress, opt => opt.MapFrom(src => src.LegalAddress))
                .ForMember(dest => dest.PostalAddress, opt => opt.MapFrom(src => src.PostalAddress))
                .ForMember(dest => dest.LegalID, opt => opt.MapFrom(src => src.LegalID))
                .ForMember(dest => dest.PositionHeld, opt => opt.MapFrom(src => src.PositionHeld))
                .ForMember(dest => dest.Powers, opt => opt.MapFrom(src => src.Powers));

            CreateMap<ProfileDTO, BankAccountViewModel>()
                .ForMember(dest => dest.BankAccountNumber, opt => opt.MapFrom(src => src.BankAccountNumber))
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.BankName))
                .ForMember(dest => dest.BankAddress, opt => opt.MapFrom(src => src.BankAddress))
                .ForMember(dest => dest.BankIdenticationCode, opt => opt.MapFrom(src => src.BankIdenticationCode));

            CreateMap<ProfileDTO, DocumentsViewModel>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.PassportNumber, opt => opt.MapFrom(src => src.PassportNumber))
                .ForMember(dest => dest.IssuingAuthority, opt => opt.MapFrom(src => src.IssuingAuthority))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.TaxIdentificationNumber, opt => opt.MapFrom(src => src.TaxIdentificationNumber))
                .ForMember(dest => dest.RegistrationAddress, opt => opt.MapFrom(src => src.RegistrationAddress))
                .ForMember(dest => dest.ResidentialAddress, opt => opt.MapFrom(src => src.ResidentialAddress));

            CreateMap<ProfileDTO, SecurityViewModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
