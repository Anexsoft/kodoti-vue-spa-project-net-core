using Core.Api.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using Service.Commons;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Authorize(Roles = RoleHelper.Admin)]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService
        ) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollection<ApplicationUserDto>>> GetAll(int page, int take) 
        {
            return await _userService.GetAll(page, take);
        }
    }
}
