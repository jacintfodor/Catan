using AutoMapper;
using Catan.Model.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Catan.Model.Test
{
    [TestClass]
    public class MapperTest
    {
        [TestMethod]
        public void MapperEdge()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Board.Components.Edge, EdgeDTO>());
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void MapperVertex()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Board.Components.Vertex, VertexDTO>());
            configuration.AssertConfigurationIsValid();
        }
        
        [TestMethod]
        public void MapperHex()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Board.Components.Hex, HexDTO>());
            configuration.AssertConfigurationIsValid();
        }
        
        [TestMethod]
        public void MapperPlayer()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Context.Players.Player, PlayerDTO>());
            configuration.AssertConfigurationIsValid();
        }
        
        [TestMethod]
        public void MapperGoods()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Context.Goods, GoodsDTO>());
            configuration.AssertConfigurationIsValid();
        }
    }
}