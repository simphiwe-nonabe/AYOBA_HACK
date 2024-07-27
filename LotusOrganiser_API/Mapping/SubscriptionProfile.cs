using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.Subscription;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionViewModel>()
                .ForMember(m => m.BusinessName, opt => opt.MapFrom(e => e.Business.Name));

            CreateMap<SubscriptionCreationModel, Subscription>()
                .ForMember(m => m.BusinessId, opt => opt.MapFrom(e => e.BusinessId));

            CreateMap<SubscriptionUpdateModel, Subscription>();
        }
    }
}