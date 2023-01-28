using AutoMapper;
using ClanManagement.BusinessLogic.Data;
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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _language;

        public LanguageController(ILanguageService language)
        {
            _language = language;
            
        }


        [HttpGet]
        public async Task<IActionResult> getLanguage()
        {

            ServiceResponse<List<GetLanguageDto>> results = await _language.getLanguange();
            if (!results.Success)
            {
                BadRequest(results);
            }
            return Ok(results);
        }


        [HttpPost]
        public async Task<IActionResult> createLanguage(AddLanguageDto lang)
        {
            ServiceResponse<GetLanguageDto> response = await _language.CreateLanguage(lang);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> updateLanguage(String id,UpdateLanguageDto lang)
        {
            ServiceResponse<GetLanguageDto> response = await _language.updateLanguage(id, lang);
            if (!response.Success)
            {
                BadRequest(response);
            }
            return Ok(response);

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteLanguage(string id)
        {
          ServiceResponse<GetLanguageDto> response=  await _language.deleteLanguage(id);
            if (response.Data==null)
            {
                return NotFound(response);
            }
            return new NoContentResult();
        }
    }
}
