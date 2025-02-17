using Application.Painter.Commands.PaintCommands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PaintAPIs.Controllers
{
    [Authorize(Policy = "RequirePainterRole")]
    public class PainterController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddEditPaint(AddEditPaintCommand request)
            => Ok(await Mediator.Send(request));
    }
}
