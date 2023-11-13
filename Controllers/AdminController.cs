using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Models.Admin;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RentalCar.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly RentalCarContext _context;
        private readonly IConfiguration _config;

        public AdminController(RentalCarContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        private string GenerateJWT(Admin admin)
        {
            var secretKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signatureKey = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Email, admin.Phone),
                new Claim(ClaimTypes.Name, admin.Fullname),
                new Claim(ClaimTypes.HomePhone, admin.Phone),
                new Claim(ClaimTypes.Role, "admin")
            };
            var token = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Audience"],
                payload,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signatureKey
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(CreateAdmin model)
        {
            try
            {
                var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password, salt);

                var admin = new Admin
                {
                    Fullname = model.Fullname,
                    Icon = model.Icon,
                    Phone = model.Phone,
                    Password = hashedPassword
                };

                _context.Admins.Add(admin);
                _context.SaveChanges();

                return Ok(new AdminDTO
                {
                    Id = admin.Id,
                    Fullname = admin.Fullname,
                    Icon = admin.Icon,
                    Phone = admin.Phone,
                    token = GenerateJWT(admin)
                });
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(AdminLogin model)
        {
            try
            {
                var admin = _context.Admins.Where(a => a.Phone.Equals(model.Phone)).FirstOrDefault();

                if (admin == null)
                {
                    throw new Exception("Phone or Password is not correct");
                }

                bool verified = BCrypt.Net.BCrypt.Verify(model.Password, admin.Password);

                if (!verified)
                {
                    throw new Exception("Phone or Password is not correct");
                }

                return Ok(new AdminDTO
                {
                    Id = admin.Id,
                    Fullname = admin.Fullname,
                    Icon = admin.Icon,
                    Phone = admin.Phone,
                    token = GenerateJWT(admin)
                });
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        // You can add more actions as needed
    }
}
