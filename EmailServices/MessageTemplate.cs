using SparkAuto.Models;

namespace SparkAuto.EmailServices
{
    public class MessageTemplate
    {
        private readonly ApplicationUser _user;
        private readonly Car _car;

        public MessageTemplate(ApplicationUser user, Car car)
        {
            _user = user;
            _car = car;
        }

        public string Message => $"Dear {_user.Name}, \nWe are pleased to inform you that your vehicle {_car.Make.ToUpper()} {_car.Model.ToUpper()}, " +
                                 $"\nwith the registration number {_car.RegistrationNumber.ToUpper()} has been successfully serviced as per your request.\n" +
                                 $"You can collect it any time Monday-Friday from 9 a.m to 6 p.m.\n\n\nKind regards, \nThe SparkAuto Garage Team.";


    }
}
