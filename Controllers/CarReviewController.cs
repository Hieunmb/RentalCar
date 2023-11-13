using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.CarReview;

namespace RentalCar.Controllers
{
    [Route("/carreview")]
    [ApiController]
    public class CarReviewController : ControllerBase
    {
        private readonly RentalCarContext _context;

        public CarReviewController(RentalCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CarReview> carReviews = _context.CarReviews.ToList();
            List<CarReviewDTO> data = carReviews.Select(cr => new CarReviewDTO
            {
                Id = cr.Id,
                UsersId = cr.UsersId,
                Message = cr.Message,
                Score = cr.Score,
                CarId = cr.CarId
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                CarReview carReview = _context.CarReviews.Find(id);
                if (carReview != null)
                {
                    return Ok(new CarReviewDTO
                    {
                        Id = carReview.Id,
                        UsersId = carReview.UsersId,
                        Message = carReview.Message,
                        Score = carReview.Score,
                        CarId = carReview.CarId
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
        public IActionResult Create(CreateCarReview model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CarReview data = new CarReview
                    {
                        UsersId = model.UsersId,
                        Message = model.Message,
                        Score = model.Score,
                        CarId = model.CarId
                    };
                    _context.CarReviews.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new CarReviewDTO
                    {
                        Id = data.Id,
                        UsersId = data.UsersId,
                        Message = data.Message,
                        Score = data.Score,
                        CarId = data.CarId
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
        public IActionResult Update(EditCarReview model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CarReview carReview = _context.CarReviews.Find(model.Id);
                    if (carReview != null)
                    {
                        carReview.UsersId = model.UsersId;
                        carReview.Message = model.Message;
                        carReview.Score = model.Score;
                        carReview.CarId = model.CarId;
                        _context.SaveChanges();
                        return Ok(new CarReviewDTO
                        {
                            Id = carReview.Id,
                            UsersId = carReview.UsersId,
                            Message = carReview.Message,
                            Score = carReview.Score,
                            CarId = carReview.CarId
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
                CarReview carReview = _context.CarReviews.Find(id);
                if (carReview == null)
                    return NotFound();

                _context.CarReviews.Remove(carReview);
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
