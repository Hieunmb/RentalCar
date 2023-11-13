using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.CarStatus;

namespace RentalCar.Controllers
{
    [Route("/car-status")]
    [ApiController]
    public class CarStatusController : ControllerBase
    {
        private readonly RentalCarContext _context;

        public CarStatusController(RentalCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CarStatus> carStatuses = _context.CarStatuses.ToList();
            List<CarStatusDTO> data = carStatuses.Select(carStatus => new CarStatusDTO
            {
                Id = carStatus.Id,
                RentalId = carStatus.RentalId,
                Thumbnail1 = carStatus.Thumbnail1,
                Thumbnail2 = carStatus.Thumbnail2
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                CarStatus carStatus = _context.CarStatuses.Find(id);
                if (carStatus != null)
                {
                    return Ok(new CarStatusDTO
                    {
                        Id = carStatus.Id,
                        RentalId = carStatus.RentalId,
                        Thumbnail1 = carStatus.Thumbnail1,
                        Thumbnail2 = carStatus.Thumbnail2
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
        public IActionResult Create(CreateCarStatus model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CarStatus data = new CarStatus
                    {
                        RentalId = model.RentalId,
                        Thumbnail1 = model.Thumbnail1,
                        Thumbnail2 = model.Thumbnail2
                    };
                    _context.CarStatuses.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new CarStatusDTO
                    {
                        Id = data.Id,
                        RentalId = data.RentalId,
                        Thumbnail1 = data.Thumbnail1,
                        Thumbnail2 = data.Thumbnail2
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
        public IActionResult Update(EditCarStatus model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CarStatus carStatus = _context.CarStatuses.Find(model.Id);
                    if (carStatus != null)
                    {
                        carStatus.RentalId = model.RentalId;
                        carStatus.Thumbnail1 = model.Thumbnail1;
                        carStatus.Thumbnail2 = model.Thumbnail2;

                        _context.SaveChanges();
                        return Ok(new CarStatusDTO
                        {
                            Id = carStatus.Id,
                            RentalId = carStatus.RentalId,
                            Thumbnail1 = carStatus.Thumbnail1,
                            Thumbnail2 = carStatus.Thumbnail2
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
                CarStatus carStatus = _context.CarStatuses.Find(id);
                if (carStatus == null)
                    return NotFound();

                _context.CarStatuses.Remove(carStatus);
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
