using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PriceListEditor.Controllers;
using PriceListEditor.Models;
using PriceListEditor.Pagination;
using PriceListEditor.Persistence.Repositories.Contracts;
using PriceListEditor.Services.Contracts;
using PriceListEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListEditor.Tests.Controller
{
    public class PriceListControllerTests
    {
        private PriceListController _priceListController;
        private IPriceListsRepository _priceListsRepository;
        private IFeaturesRepository _featuresRepository;
        private IPriceListService _priceListService;
        public PriceListControllerTests() 
        {
            //Dependencies
            _priceListsRepository = A.Fake<IPriceListsRepository>();
            _featuresRepository = A.Fake<IFeaturesRepository>();
            _priceListService = A.Fake<IPriceListService>();

            //SUT
            _priceListController = new PriceListController(_priceListsRepository, _featuresRepository, _priceListService);

        }

        [Fact]
        public void PriceListController_Index_ReturnsIActionResult()
        {
            //Arrange
            var priceLists = A.Fake<PagedList<PriceList>>();
            var page = 1;
            A.CallTo(() => _priceListsRepository.GetAll(page)).Returns(priceLists);
            //Act
            var result = _priceListController.Index(page);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();

        }

        [Fact]
        public async Task PriceListController_GetJson_ReturnsString()
        {
            //Arrange
            var priceLists = A.Fake<PagedList<PriceList>>();
            var page = 1;
            A.CallTo(() => _priceListsRepository.GetAll(page)).Returns(priceLists);
            //Act
            var result = await _priceListController.GetJson(page);
            //Assert
            result.Should().BeOfType<string>();

        }

        [Fact]
        public void PriceListController_Create_ReturnsIActionResult()
        {
            //Arrange
            var existingFeatures = A.Fake<List<Feature>>();
            A.CallTo(() => _featuresRepository.GetAll()).Returns(existingFeatures);
            //Act
            var result = _priceListController.Create();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
            
        }

        public static IEnumerable<object[]> PriceListVMData =>
            new List<object[]>()
            {
                new object[]
                {
                    new PriceListVM()
                    {
                        Name = String.Empty,
                        Features = new FeatureVM[0]
                    }
                }

            };
        public static IEnumerable<object[]> PriceListVMNullData =>
            new List<object[]>()
            {
                new object[]
                {
                    null
                }

            };

        [Theory, MemberData(nameof(PriceListVMData))]

        public async Task PriceListController_Create_ReturnsViewResult(PriceListVM priceListVM)
        {
            //Arrange
            var features = A.Fake<List<Feature>>();
            var selectedFeaturesIds = new List<int?> { 1, 2, 3 };
            A.CallTo(() => _featuresRepository.GetSelected(selectedFeaturesIds)).Returns(features);
            //Act
            var result = await _priceListController.Create(priceListVM);
            //Assert
            result.Should().BeOfType<ViewResult>();

        }

        [Theory, MemberData(nameof(PriceListVMNullData))]
        
        public async Task PriceListController_Create_ThrowsException(PriceListVM priceListVM)
        {
            //Arrange
            var features = A.Fake<List<Feature>>();
            var selectedFeaturesIds = new List<int?> { 1,2,3};
            A.CallTo(() => _featuresRepository.GetSelected(selectedFeaturesIds)).Returns(features);
            
            //Act and assert
            var result = await Assert.ThrowsAsync<NullReferenceException>(async () => await _priceListController.Create(priceListVM));

        }
    }
}
