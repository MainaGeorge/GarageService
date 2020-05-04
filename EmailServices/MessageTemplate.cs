using SparkAuto.Models;

namespace SparkAuto.EmailServices
{
    public static class MessageTemplate
    {
        public static string Message(ApplicationUser user, Car car) =>
            $"Dear {user.Name}, \nWe are pleased to inform you that your vehicle {car.Make.ToUpper()} {car.Model.ToUpper()}, " +
            $"\nwith the registration number {car.RegistrationNumber.ToUpper()} has been successfully serviced as per your request.\n" +
            $"You can collect it any time Monday-Friday from 9 a.m to 6 p.m.\n\n\nKind regards, \nThe SparkAuto Garage Team.";

        public static string ConfirmEmail(ApplicationUser user, string token) =>
            $"Dear {user.Name}, \nThank you for registering with our service. We are pleased to have you on board!\n " +
            $"You are just one step away from enjoying the full range of our services.\nClick the link below or copy and paste" +
            $"it into your browser.\n{token}\n\n\nKind regards, \nThe SparkAuto Garage Team.";

        public static string ResetPassword(ApplicationUser user, string token) =>
            $"Dear {user.Name}, \nFollow the link below to reset your password." +
            $"\n\n{token}\n\nIf you did not request a password reset please contact us as soon as possible" +
            $"\nInfo line: (+48) 765 345 678\nAlternatively send us an email with the subject 'Block my account' to allow us to\n" +
            $"momentarily suspend your account until the problem is resolved." +
            $"\n\n\nKind regards, \nThe SparkAuto Garage Team.";
    }
}
