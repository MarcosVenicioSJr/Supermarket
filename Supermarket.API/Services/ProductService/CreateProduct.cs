using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Data;
using Supermarket.API.Mapper;
using Supermarket.API.Services.ProductService.ValidatorBarCode;

namespace Supermarket.API.Services.ProductService
{
    public static class CreateProduct
    {
        public static void CreateNewProduct([FromServices] DataContext context, ProductDTO product)
        {
            bool validateBarCode = BarCodeValidator.ValidateBarCode(product.BarCode);
            if (!validateBarCode)
                throw new Exception("Barcode inválido, tente novamente com outro barcode.");

        }
    }
}
