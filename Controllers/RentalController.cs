using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.Rental;

namespace RentalCar.Controllers
{
    [Route("/rental")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly RentalCarContext _context;

        public RentalController(RentalCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Rental> rentals = _context.Rentals.ToList();
            List<RentalDTO> data = rentals.Select(rental => new RentalDTO
            {
                Id = rental.Id,
                UsersId = rental.UsersId,
                CarId = rental.CarId,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                Expected = rental.Expected,
                PickupLocation = rental.PickupLocation,
                Message = rental.Message,
                Address = rental.Address,
                Email = rental.Email,
                Telephone = rental.Telephone,
                RentalType = rental.RentalType,
                CarPrice = rental.CarPrice,
                DepositType = rental.DepositType,
                DepositAmount = rental.DepositAmount,
                AdditionalFee = rental.AdditionalFee,
                TotalAmount = rental.TotalAmount,
                Status = rental.Status,
                PaymentMethod = rental.PaymentMethod,
                IsRentPaid = rental.IsRentPaid,
                IsDepositPaid = rental.IsDepositPaid,
                IsCarReturned = rental.IsCarReturned,
                IsDepositReturned = rental.IsDepositReturned,
                IsReviewed = rental.IsReviewed
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                Rental rental = _context.Rentals.Find(id);
                if (rental != null)
                {
                    return Ok(new RentalDTO
                    {
                        Id = rental.Id,
                        UsersId = rental.UsersId,
                        CarId = rental.CarId,
                        RentalDate = rental.RentalDate,
                        ReturnDate = rental.ReturnDate,
                        Expected = rental.Expected,
                        PickupLocation = rental.PickupLocation,
                        Message = rental.Message,
                        Address = rental.Address,
                        Email = rental.Email,
                        Telephone = rental.Telephone,
                        RentalType = rental.RentalType,
                        CarPrice = rental.CarPrice,
                        DepositType = rental.DepositType,
                        DepositAmount = rental.DepositAmount,
                        AdditionalFee = rental.AdditionalFee,
                        TotalAmount = rental.TotalAmount,
                        Status = rental.Status,
                        PaymentMethod = rental.PaymentMethod,
                        IsRentPaid = rental.IsRentPaid,
                        IsDepositPaid = rental.IsDepositPaid,
                        IsCarReturned = rental.IsCarReturned,
                        IsDepositReturned = rental.IsDepositReturned,
                        IsReviewed = rental.IsReviewed
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
        public IActionResult Create(CreateRental model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Rental data = new Rental
                    {
                        UsersId = model.UsersId,
                        CarId = model.CarId,
                        RentalDate = model.RentalDate,
                        ReturnDate = model.ReturnDate,
                        Expected = model.Expected,
                        PickupLocation = model.PickupLocation,
                        Message = model.Message,
                        Address = model.Address,
                        Email = model.Email,
                        Telephone = model.Telephone,
                        RentalType = model.RentalType,
                        CarPrice = model.CarPrice,
                        DepositType = model.DepositType,
                        DepositAmount = model.DepositAmount,
                        AdditionalFee = model.AdditionalFee,
                        TotalAmount = model.TotalAmount,
                        Status = model.Status,
                        PaymentMethod = model.PaymentMethod,
                        IsRentPaid = model.IsRentPaid,
                        IsDepositPaid = model.IsDepositPaid,
                        IsCarReturned = model.IsCarReturned,
                        IsDepositReturned = model.IsDepositReturned,
                        IsReviewed = model.IsReviewed
                    };
                    _context.Rentals.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new RentalDTO
                    {
                        Id = data.Id,
                        UsersId = data.UsersId,
                        CarId = data.CarId,
                        RentalDate = data.RentalDate,
                        ReturnDate = data.ReturnDate,
                        Expected = data.Expected,
                        PickupLocation = data.PickupLocation,
                        Message = data.Message,
                        Address = data.Address,
                        Email = data.Email,
                        Telephone = data.Telephone,
                        RentalType = data.RentalType,
                        CarPrice = data.CarPrice,
                        DepositType = data.DepositType,
                        DepositAmount = data.DepositAmount,
                        AdditionalFee = data.AdditionalFee,
                        TotalAmount = data.TotalAmount,
                        Status = data.Status,
                        PaymentMethod = data.PaymentMethod,
                        IsRentPaid = data.IsRentPaid,
                        IsDepositPaid = data.IsDepositPaid,
                        IsCarReturned = data.IsCarReturned,
                        IsDepositReturned = data.IsDepositReturned,
                        IsReviewed = data.IsReviewed
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
        public IActionResult Update(EditRental model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Rental rental = _context.Rentals.Find(model.Id);
                    if (rental != null)
                    {
                        rental.UsersId = model.UsersId;
                        rental.CarId = model.CarId;
                        rental.RentalDate = model.RentalDate;
                        rental.ReturnDate = model.ReturnDate;
                        rental.Expected = model.Expected;
                        rental.PickupLocation = model.PickupLocation;
                        rental.Message = model.Message;
                        rental.Address = model.Address;
                        rental.Email = model.Email;
                        rental.Telephone = model.Telephone;
                        rental.RentalType = model.RentalType;
                        rental.CarPrice = model.CarPrice;
                        rental.DepositType = model.DepositType;
                        rental.DepositAmount = model.DepositAmount;
                        rental.AdditionalFee = model.AdditionalFee;
                        rental.TotalAmount = model.TotalAmount;
                        rental.Status = model.Status;
                        rental.PaymentMethod = model.PaymentMethod;
                        rental.IsRentPaid = model.IsRentPaid;
                        rental.IsDepositPaid = model.IsDepositPaid;
                        rental.IsCarReturned = model.IsCarReturned;
                        rental.IsDepositReturned = model.IsDepositReturned;
                        rental.IsReviewed = model.IsReviewed;

                        _context.SaveChanges();
                        return Ok(new RentalDTO
                        {
                            Id = rental.Id,
                            UsersId = rental.UsersId,
                            CarId = rental.CarId,
                            RentalDate = rental.RentalDate,
                            ReturnDate = rental.ReturnDate,
                            Expected = rental.Expected,
                            PickupLocation = rental.PickupLocation,
                            Message = rental.Message,
                            Address = rental.Address,
                            Email = rental.Email,
                            Telephone = rental.Telephone,
                            RentalType = rental.RentalType,
                            CarPrice = rental.CarPrice,
                            DepositType = rental.DepositType,
                            DepositAmount = rental.DepositAmount,
                            AdditionalFee = rental.AdditionalFee,
                            TotalAmount = rental.TotalAmount,
                            Status = rental.Status,
                            PaymentMethod = rental.PaymentMethod,
                            IsRentPaid = rental.IsRentPaid,
                            IsDepositPaid = rental.IsDepositPaid,
                            IsCarReturned = rental.IsCarReturned,
                            IsDepositReturned = rental.IsDepositReturned,
                            IsReviewed = rental.IsReviewed
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
                Rental rental = _context.Rentals.Find(id);
                if (rental == null)
                    return NotFound();

                _context.Rentals.Remove(rental);
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
