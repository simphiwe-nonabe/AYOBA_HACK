using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.ToDoListItem;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class ToDoListItemProfile : Profile
    {
        public ToDoListItemProfile()
        {
            CreateMap<ToDoListItem, ToDoListItemViewModel>()
                .ForMember(m => m.BusinessName, opt => opt.MapFrom(e => e.Business.Name));

            CreateMap<ToDoListItemCreationModel, ToDoListItem>()
                .ForMember(m => m.BusinessId, opt => opt.MapFrom(e => e.BusinessId));

        }
    }
}