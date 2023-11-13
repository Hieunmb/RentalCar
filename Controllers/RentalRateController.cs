using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.RentalRate;

namespace RentalCar.Controllers
{
    [Route("/rental-rate")]
    [ApiController]
    public class RentalRateController : ControllerBase
    {
        private readonly RentalCarContext _context;

        public RentalRateController(RentalCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<RentalRate> rentalRates = _context.RentalRates.ToList();
            List<RentalRateDTO> data = rentalRates.Select(rentalRate => new RentalRateDTO
            {
                Id = rentalRate.Id,
                UsersId = rentalRate.UsersId,
                RentalType = rentalRate.RentalType,
                Price = rentalRate.Price
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                RentalRate rentalRate = _context.RentalRates.Find(id);
                if (rentalRate != null)
                {
                    return Ok(new RentalRateDTO
                    {
                        Id = rentalRate.Id,
                        UsersId = rentalRate.UsersId,
                        RentalType = rentalRate.RentalType,
                        Price = rentalRate.Price
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
        public IActionResult Create(CreateRentalRate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RentalRate data = new RentalRate
                    {
                        UsersId = model.UsersId,
                        RentalType = model.RentalType,
                        Price = model.Price
                    };
                    _context.RentalRates.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new RentalRateDTO
                    {
                        Id = data.Id,
                        UsersId = data.UsersId,
                        RentalType = data.RentalType,
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
        public IActionResult Update(EditRentalRate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RentalRate rentalRate = _context.RentalRates.Find(model.Id);
                    if (rentalRate != null)
                    {
                        rentalRate.UsersId = model.UsersId;
                        rentalRate.RentalType = model.RentalType;
                        rentalRate.Price = model.Price;

                        _context.SaveChanges();
                        return Ok(new RentalRateDTO
                        {
                            Id = rentalRate.Id,
                            UsersId = rentalRate.UsersId,
                            RentalType = rentalRate.RentalType,
                            Price = rentalRate.Price
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
                RentalRate rentalRate = _context.RentalRates.Find(id);
                if (rentalRate == null)
                    return NotFound();

                _context.RentalRates.Remove(rentalRate);
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
