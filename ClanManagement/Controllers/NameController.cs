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

    
    public class NameController : ControllerBase
    {
        private readonly INameService _name;
        public NameController(INameService name)
        {
            _name = name;
        }
        [HttpPost]
        public async Task<IActionResult> CreateName(AddNameDto name)
        {
            ServiceResponse<GetNameDto> response = await _name.CreateName(name);
            if (!response.Success)
            {
                BadRequest(response);
            }
            return Ok(response);
        }
    }
}
