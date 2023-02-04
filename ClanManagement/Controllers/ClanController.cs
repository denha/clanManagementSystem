using ClanManagement.BusinessLogic.Data.Dto;
using ClanManagement.BusinessLogic.Data.Models;
using ClanManagement.BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClanApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClanController : ControllerBase
    {
        private readonly IClanService _clan;
        public ClanController(IClanService clan)
        {
            _clan = clan;
        }
        [HttpPost]
        public async Task<IActionResult> CreateLanguage(AddClanDto clan)
        {

            ServiceResponse<GetClanDto> Response = await _clan.CreateClan(clan);

            if (!Response.Success)
            {
                return BadRequest(Response);
            }
            return Ok(Response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClan()
        {
            ServiceResponse<List<GetClanDto>> response = await _clan.GetAllClan();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Route("{clanId}")]
        [HttpGet]
        public async Task<IActionResult> GetClanById(string clanId)
        {
         ServiceResponse<GetClanDto> response =   await _clan.GetClanById(clanId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Route("{clanId}/{lang}")]
        [HttpPut]
        public async Task<IActionResult> UpdateClan(string clanId, string lang, UpdateClanDto clan)
        {
         ServiceResponse<GetClanDto> response =    await _clan.UpdateClan(clanId, lang, clan);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Route("{clanId}")]
        [HttpDelete]
        public async Task<IActionResult>DeleteClan(string clanId)
        {
            ServiceResponse<GetClanDto> response = await _clan.DeleteClan(clanId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return new NoContentResult();
        }
    }
}
