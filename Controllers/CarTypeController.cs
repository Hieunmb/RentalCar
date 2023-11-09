using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.CarType;

namespace RentalCar.Controllers
{
    [Route("/carType")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private readonly RentalCarContext _context;
        public CarTypeController(RentalCarContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Cartype> CarTypes = _context.Cartypes.ToList();
            List<CarTypeDTO> data = new List<CarTypeDTO>();
            foreach (Cartype Cartype in CarTypes)
            {
                data.Add(new CarTypeDTO { id = Cartype.Id, name = Cartype.Name, icon = Cartype.Icon, description=Cartype.Description });
            }
            return Ok(data);
        }
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                Cartype CarType = _context.Cartypes.Find(id);
                if (CarType != null)
                {
                    return Ok(new CarTypeDTO { id = CarType.Id, name = CarType.Name, icon = CarType.Icon, description = CarType.Description });
                }
            }
            catch (Exception e)
            {
            }
            return NotFound();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateCarType model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cartype data = new Cartype { Name = model.name, Icon = model.icon, Description=model.description };
                    _context.Cartypes.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new CarTypeDTO { id = data.Id, name = data.Name, icon = data.Icon, description=data.Description });
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
        public IActionResult Update(EditCarType model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    {
                        Cartype CarType = new Cartype { Id = model.id, Name = model.name, Icon = model.icon, Description=model.description };
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
                Cartype ct = _context.Cartypes.Find(id);
                if (ct == null)
                    return NotFound();
                _context.Cartypes.Remove(ct);
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
