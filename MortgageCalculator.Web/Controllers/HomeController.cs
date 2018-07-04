using MortgageCalculator.Business.Contracts;
using MortgageCalculator.Business.Operations;
using MortgageCalculator.Dto;
using MortgageCalculator.Dto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryBase<Mortgage> _mortgageRepository;

        // Methods
        public HomeController(IRepositoryBase<Mortgage> repository)
        {
            this._mortgageRepository = repository;
        }

        public ActionResult Index()
        {
            this._mortgageRepository.GetAll();
            IEnumerable<Mortgage> all = this._mortgageRepository.GetAll();
            MortgageViewModel model = new MortgageViewModel
            {
                MortgageList = all
            };
            return base.View(model);
        }

        public ActionResult CalculateMortgage(MortgageViewModel viewModel)
        {
            Mortgage id = this._mortgageRepository.GetId(viewModel.MortgageId);
            MortgageCalculation calculation = new MortgageCalculation();
            return View(calculation.CalculateMortgage(id, viewModel.LoanAmount, viewModel.LoanTenure));
        }    

    }
}