﻿using Microsoft.AspNetCore.Mvc;
using retail_management.Dtos;
using retail_management.Models;
using retail_management.Services;

namespace retail_management.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController: ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public ProductController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _libraryService.GetAllProductsAsync();
            if (products == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No products in database.");
            }

            return StatusCode(StatusCodes.Status200OK, products);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            Product product = await _libraryService.GetProductByIdAsync(id);

            if (product == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No product found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, product);
        }
    }
}
