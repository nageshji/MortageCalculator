using MortgageCalculator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Service
{
    public class HttpService
    {
        // Methods
        public HttpResponseMessage PostResponse(string Url)
        {
            HttpClient client = new HttpClient();
            SiteUtilities utilities = new SiteUtilities();
            string appConfigValue = utilities.GetAppConfigValue("ServiceURL");
            client.BaseAddress = new Uri(appConfigValue);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(utilities.GetAppConfigValue("ServiceResponseType")));
            return client.GetAsync(Url).Result;
        }
    }



}
