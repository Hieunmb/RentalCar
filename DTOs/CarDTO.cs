using RentalCar.DTOs;

public class CarDTO
{
    public int id { get; set; }

    public string licensePlate { get; set; }

    public string model { get; set; }

    public int brandId { get; set; }

    public int cartypeId { get; set; }

    public string thumbnail { get; set; }

    public decimal price { get; set; }

    public decimal deposit { get; set; }

    public string fuelType { get; set; }

    public string transmission { get; set; }

    public string kmLimit { get; set; }

    public int modelYear { get; set; }

    public int reverseSensor { get; set; }

    public int airConditioner { get; set; }

    public int driverAirbag { get; set; }

    public int cdplayer { get; set; }

    public int brakeAssist { get; set; }

    public int seats { get; set; }

    public int status { get; set; }

    public string description { get; set; }

    public double rate { get; set; }

    public DateTime? createdAt { get; set; }

    public DateTime? updatedAt { get; set; }

    public DateTime? deletedAt { get; set; }
    public int brand_id { get; set; }

    public int carType_id { get; set; }

    public virtual BrandDTO brand { get; set; }

    public virtual CarTypeDTO cartype { get; set; }

}

