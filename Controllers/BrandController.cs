using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;

namespace RentalCar.Controllers
{
    [Route("/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly RentalCarContext _context;
        public BrandController(RentalCarContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Brand> brands = _context.Brands.ToList();
            List<BrandDTO> data= new List<BrandDTO>();
            foreach (Brand brand in brands)
            {
                data.Add(new BrandDTO { id=brand.Id, name=brand.Name,icon=brand.Icon});
            }
            return Ok(data);
        }
    }
}
