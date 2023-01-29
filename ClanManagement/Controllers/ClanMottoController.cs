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
    public class ClanMottoController : ControllerBase
    {
        private readonly IClanMottoService _clanMotto;
        public ClanMottoController(IClanMottoService clanMotto)
        {
            _clanMotto = clanMotto;
        }

        [HttpPost]
        
        public async Task<IActionResult> AddClanMotto(AddClanMottoDto clanmotto)
        {
            ServiceResponse<GetClanMottoDto> response = await _clanMotto.CreateClanMotto(clanmotto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetClanMotto()
        {
            ServiceResponse<List<GetClanMottoDto>> response = await _clanMotto.GetClanMotto();

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Route("ClanId/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetClanMottoByClanId(string id)
        {
          ServiceResponse<List<GetClanMottoDto>> result =   await _clanMotto.GetClanMottoByClanId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Route("ClanId/{id}/{langId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateClanMotto(UpdateClanMottoDto clan, string id,string langId)
        {
          ServiceResponse<GetClanMottoDto> results =  await  _clanMotto.UpdateClanMotto(id, clan, langId);
            if (!results.Success)
            {
                return BadRequest(results);
            }
            return Ok(results);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteClanMotto(string id)
        {
            ServiceResponse<GetClanMottoDto> results = await _clanMotto.DeleteClanMotto(id);
            if (!results.Success)
            {
                return BadRequest(results);
            }
            return new NoContentResult();
        }
    }
}
