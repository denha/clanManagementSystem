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
        private readonly LanguageService _langService;
        public ClanController(LanguageService langService)
        {
            _langService = langService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateLanguage(AddLanguageDto Lang)
        {

          ServiceResponse<GetLanguageDto> Response =  await _langService.CreateLanguage(Lang);

            if (!Response.Success)
            {
                return BadRequest(Response);
            }
            return Ok(Response);
        }
    }
}
