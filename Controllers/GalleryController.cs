using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.Gallery;

namespace RentalCar.Controllers
{
    [Route("/gallery")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly RentalCarContext _context;

        public GalleryController(RentalCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Gallery> galleries = _context.Galleries.ToList();
            List<GalleryDTO> data = galleries.Select(gallery => new GalleryDTO
            {
                Id = gallery.Id,
                CarId = gallery.CarId,
                Thumbnail = gallery.Thumbnail
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                Gallery gallery = _context.Galleries.Find(id);
                if (gallery != null)
                {
                    return Ok(new GalleryDTO
                    {
                        Id = gallery.Id,
                        CarId = gallery.CarId,
                        Thumbnail = gallery.Thumbnail
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
        public IActionResult Create(CreateGallery model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Gallery data = new Gallery
                    {
                        CarId = model.CarId,
                        Thumbnail = model.Thumbnail
                    };
                    _context.Galleries.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new GalleryDTO
                    {
                        Id = data.Id,
                        CarId = data.CarId,
                        Thumbnail = data.Thumbnail
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
        public IActionResult Update(EditGallery model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Gallery gallery = _context.Galleries.Find(model.Id);
                    if (gallery != null)
                    {
                        gallery.CarId = model.CarId;
                        gallery.Thumbnail = model.Thumbnail;

                        _context.SaveChanges();
                        return Ok(new GalleryDTO
                        {
                            Id = gallery.Id,
                            CarId = gallery.CarId,
                            Thumbnail = gallery.Thumbnail
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
                Gallery gallery = _context.Galleries.Find(id);
                if (gallery == null)
                    return NotFound();

                _context.Galleries.Remove(gallery);
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
