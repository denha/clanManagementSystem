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
    }
}
