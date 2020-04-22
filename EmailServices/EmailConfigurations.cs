namespace SparkAuto.EmailServices
{
    public class EmailConfigurations
    {
        public string SmtpServer { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string From { get; set; }

        public int Port { get; set; }

    }
}
