using Architecture.Application;
using Architecture.CrossCutting;
using Architecture.Model;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Architecture.Web
{
    [ApiController]
    [RouteController]
    public class UsersController : BaseController
    {
        private readonly IAuthApplicationService _authApplicationService;
        private readonly IUserApplicationService _userApplicationService;

        public UsersController
        (
            IAuthApplicationService authApplicationService,
            IUserApplicationService userApplicationService
        )
        {
            _authApplicationService = authApplicationService;
            _userApplicationService = userApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddUserModel addUserModel)
        {
            return Result(await _userApplicationService.AddAsync(addUserModel));
        }

        [AuthorizeEnum(Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Result(await _userApplicationService.DeleteAsync(id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            return Result(await _userApplicationService.GetAsync(id));
        }

        [HttpPatch("{id}/Inactivate")]
        public async Task InactivateAsync(long id)
        {
            await _userApplicationService.InactivateAsync(id);
        }

        [HttpGet("Grid")]
        public async Task<IActionResult> ListAsync([FromQuery]PagedListParameters parameters)
        {
            return Result(await _userApplicationService.ListAsync(parameters));
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return Result(await _userApplicationService.ListAsync());
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(SignInModel signInModel)
        {
            return Result(await _authApplicationService.SignInAsync(signInModel));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateUserModel updateUserModel)
        {
            return Result(await _userApplicationService.UpdateAsync(updateUserModel));
        }
    }
}
