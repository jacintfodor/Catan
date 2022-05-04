﻿using AutoMapper;

namespace Catan.Model.DTOs
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Board.Components.Edge, EdgeDTO>();
            CreateMap<Board.Components.Vertex,VertexDTO > ();
            CreateMap < Board.Components.Hex,HexDTO > ();
            CreateMap<Context.Goods, GoodsDTO>();
            CreateMap < Context.Players.Player,PlayerDTO > ();
            
            //CreateMap<Source, Destination>();
            // Additional mappings here...
        }
    }
}
