using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ready.labs.Controllers;
using ready.labs.Models;

namespace ready.labs.xunit
{
    public class authTesting
    {
        private readonly AuthController _authController;
        private readonly IConfiguration _configuration;
        public authTesting() 
        {
            _authController = new AuthController(_configuration);
        }
        
        [Fact]
        public void createUser()
        {
            UserRequestDTO user = new UserRequestDTO { Username ="Alberto", Password="Roque" };


            var result = _authController.Register(user);

            Assert.IsType<ActionResult<User>>(result);
        }
    }
}