using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Supermarket.API.Controllers;
using Supermarket.API.Data;
using Supermarket.API.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Supermarket.Test
{
    public class ProductTests
    {
        private DataContext _dbContext;
        private ProductController _controller;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
              .UseInMemoryDatabase(databaseName: "test_db")
              .Options;

            _dbContext = new DataContext(options);

            _controller = new ProductController();
        }

        [Test]
        public async Task Test_ProductController_NewProduct()
        {
            // arrange
            Product model = new Product()
            {
                Name = "Canetas",
                Description = "Usado para escrever em papel",
                Quantity = 100,
                Price = 10,
                BarCode = "5901234123457"
            };

            // act
            var response = await _controller.Post(_dbContext, model);

            // assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result is OkObjectResult);

            var okObjectResult = response.Result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

            dynamic responseValue = okObjectResult.Value;
            Assert.AreEqual("Produto criado com sucesso", responseValue.Message);
            Assert.AreEqual(model.Name, responseValue.Product.Name);
            Assert.AreEqual(model.BarCode, responseValue.Product.BarCode);
            Assert.AreEqual(model.Quantity, responseValue.Product.Quantity);
            Assert.AreEqual(1, responseValue.Product.Id);
        }

        [Test]
        public async Task Test_ProductController_GetProduct()
        {
            // arr
            Product model = new Product()
            {
                Name = "Canetas",
                Description = "Usado para escrever em papel",
                Quantity = 100,
                Price = 10,
                BarCode = "5901234123457"
            };
            await _controller.Post(_dbContext, model);

            // arr
            var data = await _controller.GetById(_dbContext, 1);
            var result = data.Result;
            //assert

            Assert.DoesNotThrow(() =>
            {
                Assert.IsNotNull(result);
            });

        }
    }
}