﻿namespace richmindale_app.Server.Helpers
{
    public class EmailSettings
    {
        public string From { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}
