using MortgageCalculator.Api.Services;
using MortgageCalculator.Business.Contracts;
using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Service
{
    public class MortgageRepostitory : IRepositoryBase<Mortgage>
    {
        // Fields
        private MortgageService mortgageService = new MortgageService();

        // Methods
        public IEnumerable<Mortgage> GetAll()
        {
            return this.mortgageService.GetMortagePlans();
        }

        public Mortgage GetId(object id)
        {
            return this.mortgageService.GetMortageDetails(int.Parse(id.ToString()));
        }
    }



}
