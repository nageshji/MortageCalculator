using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MortgageCalculator.Dto;
using MortgageCalculator.Dto.ViewModels;

namespace MortgageCalculator.Business.Operations
{
    public class MortgageCalculation
    {
        // Methods
        public CalculateMortgageViewModel CalculateMortgage(Mortgage mortgage, int loanAmount, int loanTenure)
        {
            CalculateMortgageViewModel model = new CalculateMortgageViewModel();
            int num = loanTenure * 12;
            decimal loanInterest = mortgage.InterestRate / 12;
            model.Mortgage = mortgage;
            model.LoanAmount = loanAmount;
            model.LoanTenure = loanTenure;
            decimal num3 = this.GetEmi(loanAmount, num, loanInterest);
            model.LoanEMI = num3;
            model.TotalLoan = num3 * num;
            model.TotalInterest = (num3 * num) - loanAmount;
            return model;
        }

        public decimal GetEmi(int loanAmount, int loanTenure, decimal loanInterest)
        {
            return decimal.Round((loanAmount + ((loanAmount * (loanInterest / 100M)) * loanTenure)) / loanTenure);
        }

    }
}
