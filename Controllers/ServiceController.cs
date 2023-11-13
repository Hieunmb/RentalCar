using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.Service;

namespace RentalCar.Controllers
{
    [Route("/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly RentalCarContext _context;

        public ServiceController(RentalCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Service> services = _context.Services.ToList();
            List<ServiceDTO> data = services.Select(service => new ServiceDTO
            {
                Id = service.Id,
                RentalId = service.RentalId,
                Title = service.Title,
                Description = service.Description,
                Price = service.Price
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                Service service = _context.Services.Find(id);
                if (service != null)
                {
                    return Ok(new ServiceDTO
                    {
                        Id = service.Id,
                        RentalId = service.RentalId,
                        Title = service.Title,
                        Description = service.Description,
                        Price = service.Price
                    });
                }
            }
            catch (Exception e)
            {
                // Log the exception or handle it as needed
            }
            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateService model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service data = new Service
                    {
                        RentalId = model.RentalId,
                        Title = model.Title,
                        Description = model.Description,
                        Price = model.Price
                    };
                    _context.Services.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new ServiceDTO
                    {
                        Id = data.Id,
                        RentalId = data.RentalId,
                        Title = data.Title,
                        Description = data.Description,
                        Price = data.Price
                    });
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            var msgs = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
            return BadRequest(string.Join(" | ", msgs));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(EditService model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = _context.Services.Find(model.Id);
                    if (service != null)
                    {
                        service.RentalId = model.RentalId;
                        service.Title = model.Title;
                        service.Description = model.Description;
                        service.Price = model.Price;

                        _context.SaveChanges();
                        return Ok(new ServiceDTO
                        {
                            Id = service.Id,
                            RentalId = service.RentalId,
                            Title = service.Title,
                            Description = service.Description,
                            Price = service.Price
                        });
                    }
                    else
                    {
                        return NotFound();
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
                Service service = _context.Services.Find(id);
                if (service == null)
                    return NotFound();

                _context.Services.Remove(service);
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
