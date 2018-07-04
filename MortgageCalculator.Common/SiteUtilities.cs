    using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Common
{
    public class SiteUtilities
    {
        // Methods
        public string GetAppConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }



}
