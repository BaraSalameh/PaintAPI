using Application.Admin.Commands.RoleCommands;
using Application.Admin.Commands.SystemLanguageCommands;
using Application.Admin.Commands.UserCommands;
using Application.Admin.Queries.RoleQueries;
using Application.Admin.Queries.SystemLanguageQueries;
using Application.Admin.Queries.UserQueries;
using Application.Common.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaintAPIs.Controllers;

namespace Supper.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddEditUser(AddEditUserCommand request) 
            => Ok(await Mediator.Send(request));

        [HttpPost]
        public async Task<IActionResult> ActivateUser(ActivateUserCommand request) 
            => Ok(await Mediator.Send(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand request) 
            => Ok(await Mediator.Send(request));

        [HttpGet]
        public async Task<IActionResult> UsersList([FromQuery] ListQuery<ULQ_UsersListQuery> request) 
            => Ok(await Mediator.Send(request));

        [HttpPost]
        public async Task<IActionResult> AddEditRole(AddEditRoleCommand request) 
            => Ok(await Mediator.Send(request));

        [HttpGet]
        public async Task<IActionResult> RolesList([FromQuery] ListQuery<RLQ_RolesListQuery> request)
            => Ok(await Mediator.Send(request));

        [HttpPost]
        public async Task<IActionResult> AddEditSystemLanguage(AddEditSystemLanguageCommand request)
            => Ok(await Mediator.Send(request));

        [HttpGet]
        public async Task<IActionResult> SystemLanguagesList([FromQuery] ListQuery<SLLQ_SystemLanguageListQuery> request)
            => Ok(await Mediator.Send(request));
    }
}
