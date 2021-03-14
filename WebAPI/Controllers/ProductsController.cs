﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // ProductsController bu class bir controllerdır([ApiController]) diyoruz.
    public class ProductsController : ControllerBase
    {
        //Loosely coupled:Gevşek bağlılık
        //naming convention
        //IoC Container :Inversion of control(Değişim kontrolü)
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            //Swagger --Dökümantasyon
            // bağımlılık oluşturduk(Dependency Chain)--- ctor ile çözdük.
            var result = _productService.GetAll();
            if (result.Success)
            {
                //200 döndürüyor yani. Getrequestte 200 ile çalışırız.
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
