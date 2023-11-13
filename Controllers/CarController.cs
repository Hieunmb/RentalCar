using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.Car;

namespace RentalCar.Controllers
{
    [Route("/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly RentalCarContext _context;

        public CarController(RentalCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Car> cars = _context.Cars.ToList();
            List<CarDTO> data = cars.Select(car => new CarDTO
            {
                Id = car.Id,
                LicensePlate = car.LicensePlate,
                Model = car.Model,
                BrandId = car.BrandId,
                CartypeId = car.CartypeId,
                Thumbnail = car.Thumbnail,
                Price = car.Price,
                Deposit = car.Deposit,
                FuelType = car.FuelType,
                Transmission = car.Transmission,
                KmLimit = car.KmLimit,
                ModelYear = car.ModelYear,
                ReverseSensor = car.ReverseSensor,
                AirConditioner = car.AirConditioner,
                DriverAirbag = car.DriverAirbag,
                CDplayer = car.CDplayer,
                BrakeAssist = car.BrakeAssist,
                Seats = car.Seats,
                Status = car.Status,
                Description = car.Description,
                Rate = car.Rate
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                Car car = _context.Cars.Find(id);
                if (car != null)
                {
                    return Ok(new CarDTO
                    {
                        Id = car.Id,
                        LicensePlate = car.LicensePlate,
                        Model = car.Model,
                        BrandId = car.BrandId,
                        CartypeId = car.CartypeId,
                        Thumbnail = car.Thumbnail,
                        Price = car.Price,
                        Deposit = car.Deposit,
                        FuelType = car.FuelType,
                        Transmission = car.Transmission,
                        KmLimit = car.KmLimit,
                        ModelYear = car.ModelYear,
                        ReverseSensor = car.ReverseSensor,
                        AirConditioner = car.AirConditioner,
                        DriverAirbag = car.DriverAirbag,
                        CDplayer = car.CDplayer,
                        BrakeAssist = car.BrakeAssist,
                        Seats = car.Seats,
                        Status = car.Status,
                        Description = car.Description,
                        Rate = car.Rate
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
        public IActionResult Create(CreateCar model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Car data = new Car
                    {
                        LicensePlate = model.LicensePlate,
                        Model = model.Model,
                        BrandId = model.BrandId,
                        CartypeId = model.CartypeId,
                        Thumbnail = model.Thumbnail,
                        Price = model.Price,
                        Deposit = model.Deposit,
                        FuelType = model.FuelType,
                        Transmission = model.Transmission,
                        KmLimit = model.KmLimit,
                        ModelYear = model.ModelYear,
                        ReverseSensor = model.ReverseSensor,
                        AirConditioner = model.AirConditioner,
                        DriverAirbag = model.DriverAirbag,
                        CDplayer = model.CDplayer,
                        BrakeAssist = model.BrakeAssist,
                        Seats = model.Seats,
                        Status = model.Status,
                        Description = model.Description,
                        Rate = model.Rate
                    };
                    _context.Cars.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new CarDTO
                    {
                        Id = data.Id,
                        LicensePlate = data.LicensePlate,
                        Model = data.Model,
                        BrandId = data.BrandId,
                        CartypeId = data.CartypeId,
                        Thumbnail = data.Thumbnail,
                        Price = data.Price,
                        Deposit = data.Deposit,
                        FuelType = data.FuelType,
                        Transmission = data.Transmission,
                        KmLimit = data.KmLimit,
                        ModelYear = data.ModelYear,
                        ReverseSensor = data.ReverseSensor,
                        AirConditioner = data.AirConditioner,
                        DriverAirbag = data.DriverAirbag,
                        CDplayer = data.CDplayer,
                        BrakeAssist = data.BrakeAssist,
                        Seats = data.Seats,
                        Status = data.Status,
                        Description = data.Description,
                        Rate = data.Rate
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
        public IActionResult Update(EditCar model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Car car = _context.Cars.Find(model.Id);
                    if (car != null)
                    {
                        car.LicensePlate = model.LicensePlate;
                        car.Model = model.Model;
                        car.BrandId = model.BrandId;
                        car.CartypeId = model.CartypeId;
                        car.Thumbnail = model.Thumbnail;
                        car.Price = model.Price;
                        car.Deposit = model.Deposit;
                        car.FuelType = model.FuelType;
                        car.Transmission = model.Transmission;
                        car.KmLimit = model.KmLimit;
                        car.ModelYear = model.ModelYear;
                        car.ReverseSensor = model.ReverseSensor;
                        car.AirConditioner = model.AirConditioner;
                        car.DriverAirbag = model.DriverAirbag;
                        car.CDplayer = model.CDplayer;
                        car.BrakeAssist = model.BrakeAssist;
                        car.Seats = model.Seats;
                        car.Status = model.Status;
                        car.Description = model.Description;
                        car.Rate = model.Rate;

                        _context.SaveChanges();
                        return Ok(new CarDTO
                        {
                            Id = car.Id,
                            LicensePlate = car.LicensePlate,
                            Model = car.Model,
                            BrandId = car.BrandId,
                            CartypeId = car.CartypeId,
                            Thumbnail = car.Thumbnail,
                            Price = car.Price,
                            Deposit = car.Deposit,
                            FuelType = car.FuelType,
                            Transmission = car.Transmission,
                            KmLimit = car.KmLimit,
                            ModelYear = car.ModelYear,
                            ReverseSensor = car.ReverseSensor,
                            AirConditioner = car.AirConditioner,
                            DriverAirbag = car.DriverAirbag,
                            CDplayer = car.CDplayer,
                            BrakeAssist = car.BrakeAssist,
                            Seats = car.Seats,
                            Status = car.Status,
                            Description = car.Description,
                            Rate = car.Rate
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
                Car car = _context.Cars.Find(id);
                if (car == null)
                    return NotFound();

                _context.Cars.Remove(car);
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
