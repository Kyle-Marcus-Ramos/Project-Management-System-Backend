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
            //return new List<GetCardResponseDTO>()
            //{
            //    new GetCardResponseDTO()
            //    {
            //        Position = 0,
            //        Name = "TO DO",
            //        Cards = new List<Project.Management.System.Model.DTO.Common.Cards>()
            //        {
            //            new Project.Management.System.Model.DTO.Common.Cards()
            //            {
            //                Header = "Test card",
            //                Description = "test desc",
            //                Summary = "test sum"
            //            },
            //            new Project.Management.System.Model.DTO.Common.Cards()
            //            {
            //                Header = "Test card",
            //                Description = "test desc",
            //                Summary = "test sum"
            //            },
            //            new Project.Management.System.Model.DTO.Common.Cards()
            //            {
            //                Header = "Test card",
            //                Description = "test desc",
            //                Summary = "test sum"
            //            },
            //            new Project.Management.System.Model.DTO.Common.Cards()
            //            {
            //                Header = "Test card",
            //                Description = "test desc",
            //                Summary = "test sum"
            //            }
            //        }
            //    },
            //    new GetCardResponseDTO()
            //    {
            //        Position = 1,
            //        Name = "PENDING",
            //        Cards = new List<Project.Management.System.Model.DTO.Common.Cards>()
            //        {
            //            new Project.Management.System.Model.DTO.Common.Cards()
            //            {
            //                Header = "Test card",
            //                Description = "test desc",
            //                Summary = "test sum"
            //            },
            //            new Project.Management.System.Model.DTO.Common.Cards()
            //            {
            //                Header = "Test card",
            //                Description = "test desc",
            //                Summary = "test sum"
            //            },
            //            new Project.Management.System.Model.DTO.Common.Cards()
            //            {
            //                Header = "Test card",
            //                Description = "test desc",
            //                Summary = "test sum"
            //            },
            //            new Project.Management.System.Model.DTO.Common.Cards()
            //            {
            //                Header = "Test card",
            //                Description = "test desc",
            //                Summary = "test sum"
            //            }
            //        }
            //    }
            //};
        }

        [HttpPost]
        public async Task<IEnumerable<GetCalendarByProjectIdResponseDTO>> GetCalendarByProjectId(GetCalendarByProjectIDRequestDTO calendarByProjectIDRequestDTO)
        {
            return await _cardService.GetCalendarByProjectId(calendarByProjectIDRequestDTO);
        }

        [HttpPost]
        public async Task<List<List<string>>> GetCalendarsByProjectId(GetCalendarByProjectIDRequestDTO calendarByProjectIDRequestDTO)
        {
            //return new List<Tuple<string, string, DateTime, DateTime>>()
            //{
            //    new Tuple<string, string, DateTime, DateTime>("Test 1", "Project A", DateTime.Now, DateTime.Now)
            //};

            
            List<List<string>> b = new List<List<string>>();
            var res = await _cardService.GetCalendarByProjectId(calendarByProjectIDRequestDTO);
            foreach(var r in res)
            {
                List<string> a = new List<string>();
                a.Add(r.Estimate.ToString() ?? string.Empty);
                a.Add(r.Title ?? string.Empty);
                a.Add(r.Estimate.ToString() ?? string.Empty);
                a.Add(r.DueDate.ToString() ?? string.Empty);

                b.Add(a);
            }
         
            
            return b;
            //return await _cardService.GetCalendarByProjectId(calendarByProjectIDRequestDTO);
        }
}
}
