using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MNH_Ecommerce.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;
        public ProductController(IProductRepository productRepository
            , IHttpContextAccessor httpContextAccessor
            ,IHostingEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_productRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            try
            {
                product.Validate();

                if (!product.IsValid)
                {
                    return BadRequest(product.GetMessageValidate());
                }
                if (product.Id > 0)
                {
                    _productRepository.Update(product);
                }
                else
                {
                    _productRepository.Add(product);
                }

                return Created("api/produto",product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [Authorize("Bearer")]
        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] Product product)
        {
            try
            {
                _productRepository.Delete(product);

                return Json(_productRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize("Bearer")]
        [HttpPost("SendFile")]
        public IActionResult SendFile()
        {
            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["selectedFile"];
                var nameFile = formFile.FileName;
                var extension = Path.GetExtension(nameFile);

                var arrayNameCompact = Path.GetFileNameWithoutExtension(nameFile).Take(10).ToArray();
                string newNameFile = NomeArquivo(extension, arrayNameCompact);
                var folderFiles = _hostingEnvironment.WebRootPath + "\\Files\\";
                var fullName = folderFiles + newNameFile;

                using (var streamFile = new FileStream(fullName, FileMode.Create))
                {
                    formFile.CopyTo(streamFile);
                }

                return Json(newNameFile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        private static string NomeArquivo(string extension, char[] arrayNameCompact)
        {
            var newNameFile = new string(arrayNameCompact).Replace(" ", "-");
            newNameFile += DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + extension;
            return newNameFile;
        }
    }
}
