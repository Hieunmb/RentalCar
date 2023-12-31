﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.Brand;

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
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                Brand brand = _context.Brands.Find(id);
                if (brand != null)
                {
                    return Ok(new BrandDTO { id = brand.Id, name = brand.Name, icon = brand.Icon });
                }
            }
            catch (Exception e)
            {
            }
            return NotFound();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateBrand model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Brand data = new Brand { Name = model.name, Icon=model.icon };
                    _context.Brands.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new BrandDTO { id = data.Id, name = data.Name, icon=data.Icon });
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }
            var msgs = ModelState.Values.SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage);
            return BadRequest(string.Join(" | ", msgs));
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(EditBrand model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    {
                        Brand brand = new Brand { Id = model.id, Name = model.name, Icon=model.icon };
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                Brand b = _context.Brands.Find(id);
                if (b == null)
                    return NotFound();
                _context.Brands.Remove(b);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
