﻿using System.Net.Http.Headers;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;


[ApiController]
[Route("api/Produccts")]
public class ProductController:ControllerBase
{
        private readonly StoreContext _context;
    public ProductController(StoreContext context)
    {
            _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetProducts()
    {
      var products=  await _context.Products.ToListAsync();
      return Ok(products);
    }
      [HttpGet("{id}")]
    public async Task<ActionResult> GetProducts(int id)
    {
      var product=  await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
      if (product==null  )
      return NotFound();
      return Ok(product);
    }
    

}
