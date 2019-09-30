using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.Domain.Entity;
using MNH_Ecommerce.Repository.Context;

namespace MNH_Ecommerce.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public ProductController(IProductRepository context)
        {
            _productRepository = context;
        }

        public IActionResult Index()
        {
            return View(_productRepository.GetAll());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productRepository.GetAll().FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price,FileName")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,FileName")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productRepository.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productRepository.GetAll()
                .FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Delete(product);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _productRepository.GetAll().Any(e => e.Id == id);
        }
        //[HttpPost, ActionName("SendFile")]
        //public IActionResult SendFile()
        //{
        //    try
        //    {
        //        var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["selectedFile"];
        //        var nameFile = formFile.FileName;
        //        var extension = Path.GetExtension(nameFile);

        //        var arrayNameCompact = Path.GetFileNameWithoutExtension(nameFile).Take(10).ToArray();
        //        string newNameFile = NomeArquivo(extension, arrayNameCompact);
        //        var folderFiles = _hostingEnvironment.WebRootPath + "\\Files\\";
        //        var fullName = folderFiles + newNameFile;

        //        using (var streamFile = new FileStream(fullName, FileMode.Create))
        //        {
        //            formFile.CopyTo(streamFile);
        //        }

        //        return Json(newNameFile);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }

        //}

        //private static string NomeArquivo(string extension, char[] arrayNameCompact)
        //{
        //    var newNameFile = new string(arrayNameCompact).Replace(" ", "-");
        //    newNameFile += DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + extension;
        //    return newNameFile;
        //}
    }
}
