using MortgageCalculator.Common;
using MortgageCalculator.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Service
{
    class MortgageService
    {
        // Methods
        public Mortgage GetMortageDetails(int Id)
        {
            Mortgage mortgage = null;
            SiteUtilities utilities = new SiteUtilities();
            string url = utilities.GetAppConfigValue("MortageApi") + "?id=" + Id;
            HttpResponseMessage message = new HttpService().PostResponse(url);
            if (message.IsSuccessStatusCode)
            {
                Task<string> task = message.Content.ReadAsStringAsync();
                task.Wait();
                mortgage = JsonConvert.DeserializeObject<Mortgage>(task.Result);
            }
            return mortgage;
        }

        public IEnumerable<Mortgage> GetMortagePlans()
        {
            IList<Mortgage> list = null;
            string appConfigValue = new SiteUtilities().GetAppConfigValue("MortageApi");
            HttpResponseMessage message = new HttpService().PostResponse(appConfigValue);
            if (message.IsSuccessStatusCode)
            {
                Task<string> task = message.Content.ReadAsStringAsync();
                task.Wait();
                list = JsonConvert.DeserializeObject<IList<Mortgage>>(task.Result);
            }
            return (from mortgage in list
                    orderby mortgage.MortgageType, mortgage.InterestRepayment
                    select mortgage);
        }

    }
}
