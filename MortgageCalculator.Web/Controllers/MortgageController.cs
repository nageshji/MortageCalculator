using MortgageCalculator.Business.Contracts;
using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Controllers
{
    public class MortgageController : Controller
    {
        // Fields
        private IRepositoryBase<Mortgage> _mortgageRepository;

        // Methods
        public MortgageController(IRepositoryBase<Mortgage> repository)
        {
            this._mortgageRepository = repository;
        }

        public ActionResult Index()
        {
            IEnumerable<Mortgage> all = this._mortgageRepository.GetAll();
            return View(all);
        }

        public ActionResult Details(int id)
        {
            Mortgage model = this._mortgageRepository.GetId(id);
            return View(model);
        }

    }
}