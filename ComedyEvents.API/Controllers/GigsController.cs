using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyEvents.Domain.Dtos;
using ComedyEvents.Dto;
using ComedyEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComedyEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GigsController : Controller
    {
        private readonly IGigService _gigService;

        public GigsController(IGigService gigservice)
        {
            _gigService = gigservice;
        }

        /// <summary>
        /// Get all gigs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<BaseResponseDto<IEnumerable<GigDto>>>> GetAllGigs()
        {
            BaseResponseDto<IEnumerable<GigDto>> gigs = await _gigService.GetGigs();

            if (!gigs.HasError || gigs.Data != null)
            {
                return Ok(gigs.Data);
            }
            else if (!gigs.HasError || gigs.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(gigs.Errors);
            }
        }
    }
}