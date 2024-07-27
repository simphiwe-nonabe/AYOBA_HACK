using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.Business;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Business, BusinessViewModel>();

            CreateMap<BusinessCreationModel, Business>();
        }
    }
}