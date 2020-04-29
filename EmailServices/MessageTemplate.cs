using SparkAuto.Models;

namespace SparkAuto.EmailServices
{
    public static class MessageTemplate
    {
        public static string Message(ApplicationUser user, Car car) => $"Dear {user.Name}, \nWe are pleased to inform you that your vehicle {car.Make.ToUpper()} {car.Model.ToUpper()}, " +
                                                                $"\nwith the registration number {car.RegistrationNumber.ToUpper()} has been successfully serviced as per your request.\n" +
                                                                $"You can collect it any time Monday-Friday from 9 a.m to 6 p.m.\n\n\nKind regards, \nThe SparkAuto Garage Team.";


    }
}
