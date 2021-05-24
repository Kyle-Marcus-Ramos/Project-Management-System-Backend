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
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveCard(SaveCardRequestDTO saveCardRequestDTO)
        {
            try
            {
                await _cardService.SaveCard(saveCardRequestDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error has occurred on Saving Card " + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCard(UpdateCardRequestDTO updateCardRequestDTO)
        {
            try
            {
                await _cardService.UpdateCard(updateCardRequestDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error has occurred on Saving Project " + ex);
            }
        }

        [HttpPost]
        public async Task<IEnumerable<GetCardResponseDTO>> GetCardByProjectId(GetCardRequestDTO getCardRequestDTO)
        {
            return await _cardService.GetCardByProjectId(getCardRequestDTO);
        }

        [HttpPost]
        public async Task<IEnumerable<GetCalendarByProjectIdResponseDTO>> GetCalendarByProjectId(GetCalendarByProjectIDRequestDTO calendarByProjectIDRequestDTO)
        {
            return await _cardService.GetCalendarByProjectId(calendarByProjectIDRequestDTO);
        }
    }
}
