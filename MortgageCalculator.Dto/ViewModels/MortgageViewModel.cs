using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto.ViewModels
{
    public class MortgageViewModel
    {
        // Properties
        public IEnumerable<Mortgage> MortgageList { get; set; }

        [DisplayName("Loan Amount"), Required(ErrorMessage = "Loan Amount is required"), Range(10000, 20000000, ErrorMessage = "Loan Amount must be between 10000 and 20000000")]
        public int LoanAmount { get; set; }

        [DisplayName("Loan Tenure"), Range(1, 50, ErrorMessage = "Tenure years must be between 1 and 50")]
        public int LoanTenure { get; set; }

        public string MortgageId { get; set; }
       

    }
}
