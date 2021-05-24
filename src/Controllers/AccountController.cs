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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        
        [HttpPost]
        public async Task<GetAccountByEmailPasswordResponseDTO> GetAccountByUsernamePassword(GetAccountByEmailPasswordRequestDTO accountRequest)
        {
            return await _accountService.GetAccountByEmailPassword(accountRequest);
        }

        [HttpGet]
        public async Task<IEnumerable<GetAccountAllResponseDTO>> GetAccountAll()
        {
            return await _accountService.GetAccountAll();
        }

        [HttpPost]
        public async Task<IActionResult> SaveAccount(SaveAccountRequestDTO saveAccountRequestDTO)
        {
            try
            {
                await _accountService.SaveAccount(saveAccountRequestDTO);
                return Ok();
            }
             catch(Exception ex)
            {
                return BadRequest("An error has occurred on Saving Account!" + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordRequestDTO forgetPasswordRequestDTO)
        {
            try
            {
                await _accountService.ForgetPassword(forgetPasswordRequestDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error has occurred on Saving Account!" + ex);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Health()
        {
            return Ok();
        }
    }
}
