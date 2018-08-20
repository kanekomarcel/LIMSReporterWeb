using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIMSReporterWeb.source.entity
{
    public class User
    {

        private String login;

        public String Login
        {
            get { return login; }
            set { login = value; }
        }

        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}