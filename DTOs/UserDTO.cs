﻿namespace RentalCar.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public int? Status { get; set; }
        public string token { get; set; }
    }
}
