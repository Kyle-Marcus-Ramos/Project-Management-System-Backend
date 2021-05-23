using Microsoft.AspNetCore.Mvc;
using Project.Management.System.BusinessLogic.Services.Base;
using Project.Management.System.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Project_Management_System_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IEnumerable<GetCommentByCardIdResponseDTO>> GetCommentByCardId(GetCommentByCardIdRequestDTO getCommentByCardIdRequestDTO)
        {
            return await _commentService.GetCommentByCardId(getCommentByCardIdRequestDTO);
        }

        [HttpPost]
        public async Task<IActionResult> SaveComment(SaveCommentRequestDTO saveCommentRequestDTO)
        {
            try
            {
                await _commentService.SaveComment(saveCommentRequestDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error has occurred on Saving Card " + ex);
            }
        }
    }
}
