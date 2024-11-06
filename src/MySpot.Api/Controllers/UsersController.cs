using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using MySpot.Application.Abstractions;
using MySpot.Application.Commands;

namespace MySpot.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController :ControllerBase
    {
        private readonly ICommandHandler<SignUp> _signUpHangler;

        public UsersController(ICommandHandler<SignUp> signHandler)
        {
            _signUpHangler = signHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Post(SignUp command)
        {
            command = command with {UserId = Guid.NewGuid()};
            await _signUpHangler.HandleAsync(command);
            return NoContent();
        }
    }
}
