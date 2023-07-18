using Microsoft.AspNetCore.Mvc;
using Supermarket.API.DAO;
using Supermarket.API.Data;
using Supermarket.API.Mapper;
using Supermarket.API.Models;
using Supermarket.API.Services.ProductService.ValidatorBarCode;

namespace Supermarket.API.Services.ProductService
{
    public static class CreateProduct
    {
        public static async Task<Product> CreateNewProduct([FromServices] DataContext context, Product product)
        {
            ProductDao productDao = new ProductDao();
            bool validateBarCode = BarCodeValidator.ValidateBarCode(product.BarCode);
            if (!validateBarCode)
                throw new Exception("Barcode inválido, tente novamente com outro barcode.");

            bool barCodeExists = await productDao.ExistsProduct(context, product.BarCode);
            if (barCodeExists)
                throw new Exception("O Barcode já está cadastrado, tente com outro barcode");

            try
            {
                 productDao.Save(context, product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return product;
        }
    }
}
