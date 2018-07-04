using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto.ViewModels
{
    public class CalculateMortgageViewModel
    {
        public Mortgage Mortgage { get; set; }

        [DisplayName("Loan amount")]
        public int LoanAmount { get; set; }

        [DisplayName("Loan Tenure")]
        public int LoanTenure { get; set; }

        [DisplayName("Monthly Repayment")]
        public decimal LoanEMI { get; set; }

        [DisplayName("Total Loan amount")]
        public decimal TotalLoan { get; set; }
        [DisplayName("Total Interest")]
        public decimal TotalInterest { get; set; }

    }
}
