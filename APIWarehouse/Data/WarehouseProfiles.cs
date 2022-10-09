using AutoMapper;
using APIWarehouse.Data.Dtos;
using APIWarehouse.Data.Models;


namespace APIWarehouse.Data
{
    public class WarehouseProfiles : Profile
    {
        public WarehouseProfiles()
        {

            CreateMap<UpdateItemDto, Item>();
            CreateMap<WarehouseDto, Warehouse>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                ).ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                ).ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => $"{src.Description}")
                ).ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => $"{src.Address}")
                );
            CreateMap<Warehouse, WarehouseDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                ).ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                ).ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => $"{src.Description}")
                ).ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => $"{src.Address}")
                );
            CreateMap<UpdateZoneDto, Zone>();
            //CreateMap<DeleteZoneDto, Zone>();
            CreateMap<ZoneDto, Zone>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                ).ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                );
            CreateMap<Zone, ZoneDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                ).ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                );

            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
        }
        
    }
}
