using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.Incident;

namespace RentalCar.Controllers
{
    [Route("/incident")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly RentalCarContext _context;

        public IncidentController(RentalCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Incident> incidents = _context.Incidents.ToList();
            List<IncidentDTO> data = incidents.Select(incident => new IncidentDTO
            {
                Id = incident.Id,
                RentalId = incident.RentalId,
                Title = incident.Title,
                Thumbnail = incident.Thumbnail,
                Description = incident.Description,
                Expense = incident.Expense
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                Incident incident = _context.Incidents.Find(id);
                if (incident != null)
                {
                    return Ok(new IncidentDTO
                    {
                        Id = incident.Id,
                        RentalId = incident.RentalId,
                        Title = incident.Title,
                        Thumbnail = incident.Thumbnail,
                        Description = incident.Description,
                        Expense = incident.Expense
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
        public IActionResult Create(CreateIncident model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Incident data = new Incident
                    {
                        RentalId = model.RentalId,
                        Title = model.Title,
                        Thumbnail = model.Thumbnail,
                        Description = model.Description,
                        Expense = model.Expense
                    };
                    _context.Incidents.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new IncidentDTO
                    {
                        Id = data.Id,
                        RentalId = data.RentalId,
                        Title = data.Title,
                        Thumbnail = data.Thumbnail,
                        Description = data.Description,
                        Expense = data.Expense
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
        public IActionResult Update(EditIncident model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Incident incident = _context.Incidents.Find(model.Id);
                    if (incident != null)
                    {
                        incident.RentalId = model.RentalId;
                        incident.Title = model.Title;
                        incident.Thumbnail = model.Thumbnail;
                        incident.Description = model.Description;
                        incident.Expense = model.Expense;

                        _context.SaveChanges();
                        return Ok(new IncidentDTO
                        {
                            Id = incident.Id,
                            RentalId = incident.RentalId,
                            Title = incident.Title,
                            Thumbnail = incident.Thumbnail,
                            Description = incident.Description,
                            Expense = incident.Expense
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
                Incident incident = _context.Incidents.Find(id);
                if (incident == null)
                    return NotFound();

                _context.Incidents.Remove(incident);
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
