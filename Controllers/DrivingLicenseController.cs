using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.DrivingLicense;

namespace RentalCar.Controllers
{
    [Route("/drivinglicense")]
    [ApiController]
    public class DrivingLicenseController : ControllerBase
    {
        private readonly RentalCarContext _context;

        public DrivingLicenseController(RentalCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<DrivingLicense> drivingLicenses = _context.DrivingLicenses.ToList();
            List<DrivingLicenseDTO> data = drivingLicenses.Select(dl => new DrivingLicenseDTO
            {
                Id = dl.Id,
                UsersId = dl.UsersId,
                Icon = dl.Icon,
                Description = dl.Description
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                DrivingLicense drivingLicense = _context.DrivingLicenses.Find(id);
                if (drivingLicense != null)
                {
                    return Ok(new DrivingLicenseDTO
                    {
                        Id = drivingLicense.Id,
                        UsersId = drivingLicense.UsersId,
                        Icon = drivingLicense.Icon,
                        Description = drivingLicense.Description
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
        public IActionResult Create(CreateDrivingLicense model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DrivingLicense data = new DrivingLicense
                    {
                        UsersId = model.UsersId,
                        Icon = model.Icon,
                        Description = model.Description
                    };
                    _context.DrivingLicenses.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new DrivingLicenseDTO
                    {
                        Id = data.Id,
                        UsersId = data.UsersId,
                        Icon = data.Icon,
                        Description = data.Description
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
        public IActionResult Update(EditDrivingLicense model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DrivingLicense drivingLicense = _context.DrivingLicenses.Find(model.Id);
                    if (drivingLicense != null)
                    {
                        drivingLicense.UsersId = model.UsersId;
                        drivingLicense.Icon = model.Icon;
                        drivingLicense.Description = model.Description;
                        _context.SaveChanges();
                        return Ok(new DrivingLicenseDTO
                        {
                            Id = drivingLicense.Id,
                            UsersId = drivingLicense.UsersId,
                            Icon = drivingLicense.Icon,
                            Description = drivingLicense.Description
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
                DrivingLicense drivingLicense = _context.DrivingLicenses.Find(id);
                if (drivingLicense == null)
                    return NotFound();

                _context.DrivingLicenses.Remove(drivingLicense);
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
