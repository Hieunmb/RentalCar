using System;
using System.Collections.Generic;
using System.Linq;
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
            List<CarDTO> data = new List<CarDTO>();

            foreach (Car car in cars)
            {
                data.Add(new CarDTO
                {
                    id = car.Id,
                    licensePlate = car.LicensePlate,
                    model = car.Model,
                    brandId = car.BrandId,
                    cartypeId = car.CartypeId,
                    thumbnail = car.Thumbnail,
                    price = car.Price,
                    deposit = car.Deposit,
                    fuelType = car.FuelType,
                    transmission = car.Transmission,
                    kmLimit = car.KmLimit,
                    modelYear = car.ModelYear,
                    reverseSensor = car.ReverseSensor,
                    airConditioner = car.AirConditioner,
                    driverAirbag = car.DriverAirbag,
                    cdplayer = car.CDplayer,
                    brakeAssist = car.BrakeAssist,
                    seats = car.Seats,
                    status = car.Status,
                    description = car.Description,
                    rate = car.Rate,
                    createdAt = car.CreatedAt,
                    updatedAt = car.UpdatedAt,
                    deletedAt = car.DeletedAt,
                    brand_id = car.BrandId, // Assuming CategoryId is the correct property name
                    carType_id = car.CartypeId,   // Assuming CarTypeId is the correct property name
                    brand = new BrandDTO
                    {
                        id = car.Brand.Id,
                        name = car.Brand.Name,
                        icon = car.Brand.Icon
                    },
                    cartype = new CarTypeDTO
                    {
                        id = car.Cartype.Id,
                        name = car.Cartype.Name,
                        icon = car.Cartype.Icon,
                    }
                });
            }

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
                        id = car.Id,
                        licensePlate = car.LicensePlate,
                        model = car.Model,
                        brandId = car.BrandId,
                        cartypeId = car.CartypeId,
                        thumbnail = car.Thumbnail,
                        price = car.Price,
                        deposit = car.Deposit,
                        fuelType = car.FuelType,
                        transmission = car.Transmission,
                        kmLimit = car.KmLimit,
                        modelYear = car.ModelYear,
                        reverseSensor = car.ReverseSensor,
                        airConditioner = car.AirConditioner,
                        driverAirbag = car.DriverAirbag,
                        cdplayer = car.CDplayer,
                        brakeAssist = car.BrakeAssist,
                        seats = car.Seats,
                        status = car.Status,
                        description = car.Description,
                        rate = car.Rate,
                        createdAt = car.CreatedAt,
                        updatedAt = car.UpdatedAt,
                        deletedAt = car.DeletedAt,
                        brand_id = car.BrandId,
                        carType_id = car.CartypeId,
                        brand = new BrandDTO
                        {
                            id = car.Brand.Id,
                            name = car.Brand.Name,
                            icon = car.Brand.Icon
                        },
                        cartype = new CarTypeDTO
                        {
                            id = car.Cartype.Id,
                            name = car.Cartype.Name,
                            icon=car.Cartype.Icon
                        }
                    });
                }
            }
            catch (Exception e)
            {
                // Log or handle the exception accordingly
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
                    Car car = new Car
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
                        Rate = model.Rate,
                        // Set other properties from model
                    };

                    _context.Cars.Add(car);
                    _context.SaveChanges();

                    return Created($"get-by-id?id={car.Id}", new CarDTO
                    {
                        id = car.Id,
                        licensePlate = car.LicensePlate,
                        model = car.Model,
                        brandId = car.BrandId,
                        cartypeId = car.CartypeId,
                        thumbnail = car.Thumbnail,
                        price = car.Price,
                        deposit = car.Deposit,
                        fuelType = car.FuelType,
                        transmission = car.Transmission,
                        kmLimit = car.KmLimit,
                        modelYear = car.ModelYear,
                        reverseSensor = car.ReverseSensor,
                        airConditioner = car.AirConditioner,
                        driverAirbag = car.DriverAirbag,
                        cdplayer = car.CDplayer,
                        brakeAssist = car.BrakeAssist,
                        seats = car.Seats,
                        status = car.Status,
                        description = car.Description,
                        rate = car.Rate,
                        createdAt = car.CreatedAt,
                        updatedAt = car.UpdatedAt,
                        deletedAt = car.DeletedAt,
                        brand_id = car.BrandId,
                        carType_id = car.CartypeId,
                        brand = new BrandDTO
                        {
                            id = car.Brand.Id,
                            name = car.Brand.Name,
                            icon = car.Brand.Icon
                        },
                        cartype = new CarTypeDTO
                        {
                            id = car.Cartype.Id,
                            name = car.Cartype.Name,
                            icon = car.Cartype.Icon,
                        }
                    });
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
                        // Update other properties from model

                        _context.SaveChanges();
                        return Ok(new CarDTO
                        {
                            id = car.Id,
                            licensePlate = car.LicensePlate,
                            model = car.Model,
                            brandId = car.BrandId,
                            cartypeId = car.CartypeId,
                            thumbnail = car.Thumbnail,
                            price = car.Price,
                            deposit = car.Deposit,
                            fuelType = car.FuelType,
                            transmission = car.Transmission,
                            kmLimit = car.KmLimit,
                            modelYear = car.ModelYear,
                            reverseSensor = car.ReverseSensor,
                            airConditioner = car.AirConditioner,
                            driverAirbag = car.DriverAirbag,
                            cdplayer = car.CDplayer,
                            brakeAssist = car.BrakeAssist,
                            seats = car.Seats,
                            status = car.Status,
                            description = car.Description,
                            rate = car.Rate,
                            createdAt = car.CreatedAt,
                            updatedAt = car.UpdatedAt,
                            deletedAt = car.DeletedAt,
                            brand_id = car.BrandId,
                            carType_id = car.CartypeId,
                            brand = new BrandDTO
                            {
                                id = car.Brand.Id,
                                name = car.Brand.Name,
                                icon = car.Brand.Icon
                            },
                            cartype = new CarTypeDTO
                            {
                                id = car.Cartype.Id,
                                name = car.Cartype.Name,
                                icon =car.Cartype.Icon,
                            }
                        });
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