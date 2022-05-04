using AutoMapper;
using Catan.Model.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Catan.Model.Test
{
    [TestClass]
    public class MapperTest
    {
        [TestMethod]
        public void MapperTestCase()
        {
            var configuration = Mapping.Mapper.ConfigurationProvider;
            configuration.AssertConfigurationIsValid();
        }
    }
}