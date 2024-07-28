using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.Message;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageViewModel>()
                .ForMember(m => m.BusinessName, opt => opt.MapFrom(e => e.Business.Name));

            CreateMap<MessageCreationModel, Message>()
                .ForMember(m => m.BusinessId, opt => opt.MapFrom(e => e.BusinessId));

        }
    }
}