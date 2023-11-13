using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.Contactusquery;

namespace RentalCar.Controllers
{
    [Route("/contactusquery")]
    [ApiController]
    public class ContactusqueryController : ControllerBase
    {
        private readonly RentalCarContext _context;

        public ContactusqueryController(RentalCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Contactusquery> contactusqueries = _context.Contactusqueries.ToList();
            List<ContactusqueryDTO> data = contactusqueries.Select(cuq => new ContactusqueryDTO
            {
                Id = cuq.Id,
                UsersId = cuq.UsersId,
                Name = cuq.Name,
                Email = cuq.Email,
                Phone = cuq.Phone,
                Message = cuq.Message,
                Status = cuq.Status
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                Contactusquery contactusquery = _context.Contactusqueries.Find(id);
                if (contactusquery != null)
                {
                    return Ok(new ContactusqueryDTO
                    {
                        Id = contactusquery.Id,
                        UsersId = contactusquery.UsersId,
                        Name = contactusquery.Name,
                        Email = contactusquery.Email,
                        Phone = contactusquery.Phone,
                        Message = contactusquery.Message,
                        Status = contactusquery.Status
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
        public IActionResult Create(CreateContactusquery model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Contactusquery data = new Contactusquery
                    {
                        UsersId = model.UsersId,
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        Message = model.Message,
                        Status = model.Status
                    };
                    _context.Contactusqueries.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new ContactusqueryDTO
                    {
                        Id = data.Id,
                        UsersId = data.UsersId,
                        Name = data.Name,
                        Email = data.Email,
                        Phone = data.Phone,
                        Message = data.Message,
                        Status = data.Status
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
        public IActionResult Update(EditContactusquery model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Contactusquery contactusquery = _context.Contactusqueries.Find(model.Id);
                    if (contactusquery != null)
                    {
                        contactusquery.UsersId = model.UsersId;
                        contactusquery.Name = model.Name;
                        contactusquery.Email = model.Email;
                        contactusquery.Phone = model.Phone;
                        contactusquery.Message = model.Message;
                        contactusquery.Status = model.Status;
                        _context.SaveChanges();
                        return Ok(new ContactusqueryDTO
                        {
                            Id = contactusquery.Id,
                            UsersId = contactusquery.UsersId,
                            Name = contactusquery.Name,
                            Email = contactusquery.Email,
                            Phone = contactusquery.Phone,
                            Message = contactusquery.Message,
                            Status = contactusquery.Status
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
                Contactusquery contactusquery = _context.Contactusqueries.Find(id);
                if (contactusquery == null)
                    return NotFound();

                _context.Contactusqueries.Remove(contactusquery);
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
