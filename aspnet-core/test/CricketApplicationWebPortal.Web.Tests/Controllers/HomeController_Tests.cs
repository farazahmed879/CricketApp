using System.Threading.Tasks;
using CricketApplicationWebPortal.Models.TokenAuth;
using CricketApplicationWebPortal.Web.Controllers;
using Shouldly;
using Xunit;

namespace CricketApplicationWebPortal.Web.Tests.Controllers
{
    public class HomeController_Tests: CricketApplicationWebPortalWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}