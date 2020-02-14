using CSACC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CSACC
{
    class Config
    {
        public static String DbProvider = ConfigurationManager.AppSettings.Get("databaseProvider");
        public static String DbSource   = ConfigurationManager.AppSettings.Get("databasePath");
    }
}
