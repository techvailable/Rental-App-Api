
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebAppApi.Helping;
using RentalWebAppApi.Models;
using RentalWebService.DTOs;
using RentalWebService.IServices;
using System.Text.Json.Serialization;
using WeightChopperApi.Helping;

namespace RentalWebAppApi.Controllers
{
    [ApiController]
    public class ProductController : PrivateController
    {
        private readonly IProductService productService;
        private readonly IProcedureService procedureService;
        private readonly IAdminUserService adminUserService;
        private readonly IWebHostEnvironment hostEnvironment;
        public ProductController(IProductService productService, IProcedureService procedureService, IWebHostEnvironment hostEnvironment, IAdminUserService adminUserService)
        {
            this.productService = productService;
            this.procedureService = procedureService;
            this.hostEnvironment = hostEnvironment;
            this.adminUserService = adminUserService;
        }
        //[HttpGet]
        //[Route("api/[controller]/[action]")]
        //public async Task<IActionResult> Types()
        //{
        //    //var en = Enums.ProductTypes
        //    try
        //    {
        //        var categories = await productService.Get();
        //        if (categories.Any())
        //        {
        //            productModel.ProductDtoList = categories;
        //            productModel.ResponseDto = GetOkResponse();
        //            productModel.ImagePath = string.Format("{0}://{1}{2}/images/", Request.Scheme, Request.Host, Request.PathBase);
        //        }
        //        else
        //        {
        //            productModel.ResponseDto = GetNotFoundResponse();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        productModel.ResponseDto = GetExeceptionResponse();
        //        return StatusCode(StatusCodes.Status500InternalServerError, productModel);
        //    }
        //    return Ok(E);

        //}
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var productModel = new ProductModel();
            try
            {
                var categories = await productService.Get();
                if (categories.Any())
                {
                    productModel.ProductDtoList = categories;
                    productModel.ResponseDto = GetOkResponse();
                    productModel.ImagePath = string.Format("{0}://{1}{2}/images/", Request.Scheme, Request.Host, Request.PathBase);
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> Featured()
        {
            var productModel = new ProductModel();
            try
            {
                var categories = await productService.GetFeatured();
                if (categories.Any())
                {
                    productModel.ProductDtoList = categories;
                    productModel.ResponseDto = GetOkResponse();
                    productModel.ImagePath = string.Format("{0}://{1}{2}/staticfiles/images/", Request.Scheme, Request.Host, Request.PathBase);

                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }

        [HttpGet]
        [Route("api/[controller]/{Id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetById(int Id)
        {
            var productModel = new ProductModel();
            try
            {
                var productDto = await productService.GetById(Id);
                if (productDto != null)
                {
                    productModel.ProductDto = productDto;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);
        }
        [HttpPost]
        [Route("api/[controller]")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add([FromForm] ProductSaveModel productSave)
        {

            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var imageFile = CommonMethods.SaveImage(productSave.ImageFile, hostEnvironment);
                    var product = new ProductDto
                    {
                        Name = productSave.Name,
                        Description = productSave.Description,
                        ShortDescription = productSave.ShortDescription,
                        BrandId = productSave.BrandId,
                        CategoryId = productSave.CategoryId,
                        Featured = productSave.Featured,
                        Notes = productSave.Notes,
                        Price = productSave.Price,
                        ProductIncludes = productSave.ProductIncludes,
                        Quantity = productSave.Quantity,
                        SKU = productSave.SKU,
                        Specifications = productSave.Specifications,
                        Status = productSave.Status,
                        SubCategoryId = productSave.SubCategoryId,
                        CreatedAt = DateTime.Now.Date,
                        Image = imageFile
                    };
                    var response = await productService.Add(product);
                    return Ok(new ProductModel { ResponseDto = response });
                }
                else
                {
                    return Ok(new ProductModel { ResponseDto = GetAuthorizeResponse() }); ;
                }
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new ProductModel { ResponseDto = ResponseDto });
            }
        }
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(Int64 Id)
        {
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var response = await productService.DeleteById(Id);
                    return Ok(new ProductModel { ResponseDto = response });
                }
                else
                {
                    return Ok(new ProductModel { ResponseDto = GetAuthorizeResponse() }); ;
                }
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new ProductModel { ResponseDto = ResponseDto });
            }
        }
        [HttpPatch]
        [Route("api/[controller]")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("Id")?.Value);
                var valid = await adminUserService.GetById(userId);
                if (valid != null)
                {
                    var response = await productService.Update(productDto);
                    return Ok(new ProductModel { ResponseDto = response });
                }

                else
                {
                    return Ok(new ProductModel { ResponseDto = GetAuthorizeResponse() }); ;
                }
            }
            catch (Exception ex)
            {
                var ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, new ProductModel { ResponseDto = ResponseDto });
            }
        }

        #region Procedures 
        [HttpGet]
        [Route("api/[controller]/[action]/{storeId}")]
        public async Task<IActionResult> Store(Int64 storeId)
        {
            var productModel = new ProductModel();
            try
            {
                var products = await procedureService.GetProductByStore(storeId);
                if (products.Any())
                {
                    productModel.SpGetProductsByStoreDtos = products;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> SubBrandCategory(Int64 categoryId, Int64 brandId, Int64 subCategoryId)
        {
            var productModel = new ProductModel();
            try
            {
                var products = await procedureService.GetProductBySubBrandCategory(categoryId, brandId, subCategoryId);
                if (products.Any())
                {
                    productModel.SpGetProductsByStoreDtos = products;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> BrandCategory(Int64 categoryId, Int64 brandId)
        {
            var productModel = new ProductModel();
            try
            {
                var products = await procedureService.GetProductByBrandCategory(categoryId, brandId);
                if (products.Any())
                {
                    productModel.SpGetProductsByStoreDtos = products;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }
        [HttpGet]
        [Route("api/[controller]/[action]/{brandId}")]
        public async Task<IActionResult> Brand(Int64 brandId)
        {
            var productModel = new ProductModel();
            try
            {
                var products = await procedureService.GetProductByBrand(brandId);
                if (products.Any())
                {
                    productModel.SpGetProductsByStoreDtos = products;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }
        [HttpGet]
        [Route("api/[controller]/[action]/{subCategoryId}")]
        public async Task<IActionResult> SubCategory(Int64 subCategoryId)
        {
            var productModel = new ProductModel();
            try
            {
                var products = await procedureService.GetProductBySubCategory(subCategoryId);
                if (products.Any())
                {
                    productModel.SpGetProductsByStoreDtos = products;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> StoreSubBrandCategory(Int64 storeId, Int64 categoryId, Int64 subCategoryId, Int64 brandId)
        {
            var productModel = new ProductModel();
            try
            {
                var products = await procedureService.GetProductByStoreSubBrandCategory(storeId, categoryId, subCategoryId, brandId);
                if (products.Any())
                {
                    productModel.SpGetProductsByStoreDtos = products;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> StoreCategory(Int64 storeId, Int64 categoryId)
        {
            var productModel = new ProductModel();
            try
            {
                var products = await procedureService.GetProductByStoreCategory(storeId, categoryId);
                if (products.Any())
                {
                    productModel.SpGetProductsByStoreDtos = products;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> StoreSUBCategory(Int64 storeId, Int64 categoryId, Int64 subCategoryId)
        {
            var productModel = new ProductModel();
            try
            {
                var products = await procedureService.GetProductByStoreSUBCategory(storeId, categoryId, subCategoryId);
                if (products.Any())
                {
                    productModel.SpGetProductsByStoreDtos = products;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }
        [HttpGet]
        [Route("api/[controller]/[action]/{categoryId}")]
        public async Task<IActionResult> Category(Int64 categoryId)
        {
            var productModel = new ProductModel();
            try
            {
                var products = await procedureService.GetProductByCategory(categoryId);
                if (products.Any())
                {
                    productModel.SpGetProductsByStoreDtos = products;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }

        [HttpGet]
        [Route("api/[controller]/[action]/{filter}")]
        public async Task<IActionResult> Search(string filter)
        {
            var productModel = new ProductModel();
            try
            {
                var products = await procedureService.GetProductBySearch(filter);
                if (products.Any())
                {
                    productModel.SpGetProductsByStoreDtos = products;
                    productModel.ResponseDto = GetOkResponse();
                }
                else
                {
                    productModel.ResponseDto = GetNotFoundResponse();
                }
            }
            catch (Exception ex)
            {
                productModel.ResponseDto = GetExeceptionResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, productModel);
            }
            return Ok(productModel);

        }
        #endregion
    }
}
