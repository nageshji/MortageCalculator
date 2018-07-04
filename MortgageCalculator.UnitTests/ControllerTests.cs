using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using Moq;
using MortgageCalculator.Dto;
using MortgageCalculator.Business.Contracts;
using MortgageCalculator.Web.Controllers;
using MortgageCalculator.Dto.ViewModels;

namespace MortgageCalculator.Tests
{
    /* TODO: Put Mocks on Constructor() */
    [TestClass]
    public class ControllerTests
    {
        private Mock<IRepositoryBase<Mortgage>> mockRepositoryMortgage;

        /*
         * Check if the 1st Page receives an Empty Mortgage Object to construct the View
         */ 
        [TestMethod]
        public void Home_Index_ShouldPassMortgagesToTheView()
        {
            var mortgages = new List<Mortgage> { new Mortgage { MortgageId = 1 },
                                                 new Mortgage { MortgageId = 2 } };

            mockRepositoryMortgage = new Mock<IRepositoryBase<Mortgage>>();
            mockRepositoryMortgage.Setup(m => m.GetAll()).Returns(mortgages.AsQueryable());

            HomeController controller = new HomeController(mockRepositoryMortgage.Object);

            ViewResult result = controller.Index() as ViewResult;
            MortgageViewModel mortgage = (MortgageViewModel)result.ViewData.Model;

            Assert.IsNotNull(result);
            Assert.IsNotNull(mortgage);          
        }

        /*
         * Check if the Post works and Redirect to next Page (CalculateMortgage)
         */
        [TestMethod]
        public void Home_IndexPost_ShouldRedirectToCalculateMortgage()
        {
            var mortgages = new List<Mortgage> { new Mortgage { MortgageId = 1, InterestRate = 1, Name = "test"  },
                                                 new Mortgage { MortgageId = 2, InterestRate = 1, Name = "test2"  } };

            mockRepositoryMortgage = new Mock<IRepositoryBase<Mortgage>>();
            mockRepositoryMortgage.Setup(m => m.GetAll()).Returns(mortgages.AsEnumerable);

            HomeController controller = new HomeController(mockRepositoryMortgage.Object);

            Mock<Mortgage> mockMortgage = new Mock<Mortgage>();

            MortgageViewModel mortgageViewModel = new MortgageViewModel();
            mortgageViewModel.LoanAmount = 1000000;
            mortgageViewModel.LoanTenure = 10;
            mortgageViewModel.MortgageId = "9";

            RedirectToRouteResult result = (RedirectToRouteResult)controller.CalculateMortgage(mortgageViewModel) as RedirectToRouteResult;

            var viewModel = controller.ViewData.Model as Mortgage;

            Assert.IsNotNull(result);   
           
        }


        /*
         * Check if the 1st Page receives an Empty Mortgage Object to construct the View
         */
        [TestMethod]
        public void Mortgage_Index_ShouldPassAllMortgagesToTheView()
        {
            var mortgages = new List<Mortgage> { new Mortgage { MortgageId = 1 },
                                                 new Mortgage { MortgageId = 2 } };

            mockRepositoryMortgage = new Mock<IRepositoryBase<Mortgage>>();
            mockRepositoryMortgage.Setup(m => m.GetAll()).Returns(mortgages.AsEnumerable);

            MortgageController controller = new MortgageController(mockRepositoryMortgage.Object);

            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<Mortgage> emortgages = (IEnumerable<Mortgage>)result.ViewData.Model;

            Assert.IsNotNull(result);
            Assert.IsNotNull(emortgages);
            Assert.AreEqual(2, emortgages.Count());
            Assert.AreEqual(mortgages, emortgages);
        }

        /*
         * Check if the 2nd Page loads a Valid Mortgage
         */
        [TestMethod]
        public void Mortgage__ShouldLoadAValidMortgage()
        {
            var mortgage = new Mortgage() { MortgageId = 9, InterestRate = 1, Name="test" };
            mockRepositoryMortgage = new Mock<IRepositoryBase<Mortgage>>();
            mockRepositoryMortgage.Setup(m => m.GetId(9)).Returns(mortgage);

            MortgageController controller = new MortgageController(mockRepositoryMortgage.Object);

            ViewResult result = controller.Details(9) as ViewResult;

            var viewModel = controller.ViewData.Model as Mortgage;

            Assert.IsNotNull(result);
            Assert.IsNotNull(viewModel);
            Assert.IsTrue(viewModel.MortgageId == mortgage.MortgageId);
            Assert.AreEqual(viewModel, mortgage);
            Assert.AreSame(viewModel, mortgage);
        }

        

    }
}
