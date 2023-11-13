using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Incident
{
    public class CreateIncident
    {
        [Required]
        public int RentalId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        public string Description { get; set; }

        public decimal? Expense { get; set; }
    }
}
