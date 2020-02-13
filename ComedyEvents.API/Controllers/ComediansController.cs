using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyEvents.Domain.Dtos;
using ComedyEvents.Dto;
using ComedyEvents.Domain.Models;
using ComedyEvents.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ComedyEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComediansController : ControllerBase
    {
        private readonly IComedianService _comedianService;

        public ComediansController(IComedianService comedianService)
        {
            _comedianService = comedianService;
        }
        /// <summary>
        /// Return list of comedian
        /// </summary>
        /// <returns>IEnumerable of comedian</returns>
        [HttpGet]
        public async Task<ActionResult<BaseResponseDto<IEnumerable<ComedianDto>>>> Get()
        {

            BaseResponseDto<IEnumerable<ComedianDto>> comedian = await _comedianService.GetComedians();

            if (!comedian.HasError || comedian.Data != null)
            {
                return Ok(comedian.Data);
            }
            else if (!comedian.HasError || comedian.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(comedian.Errors);
            }
        }

        /// <summary>
        /// Create a new comedian in data base
        /// </summary>
        /// <param name="comedian"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseResponseDto<ComedianDto>>> AddComedian(Comedian comedian)
        {

            BaseResponseDto<ComedianDto> newcomedian = await _comedianService.CreateComedian(comedian);

            if (!newcomedian.HasError || newcomedian.Data != null)
            {
                return Ok(newcomedian.Data);
            }
            else if (!newcomedian.HasError || newcomedian.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(newcomedian.Errors);
            }
        }

        /// <summary>
        /// Retur a single comedian with id  
        /// </summary>
        /// <param name="id">Id is a Guid</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetById([FromRoute]string id)
        {
            Guid _id = Guid.Parse(id);

            BaseResponseDto<ComedianDto> comedian = await _comedianService.GetAsync(_id);

            if (!comedian.HasError || comedian.Data != null)
            {
                return Ok(comedian.Data);
            }
            else if (!comedian.HasError || comedian.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(comedian.Errors);
            }
        }

        /// <summary>
        /// Update comedian
        /// </summary>
        /// <param name="id">Is a Guid</param>
        /// <param name="comedian"></param>
        /// <returns></returns>
        
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateComedian([FromRoute]string id, Comedian comedian)
        {
            Guid _id = Guid.Parse(id);
            BaseResponseDto<ComedianDto> oldComedian = await _comedianService.UpDateComedian(_id, comedian);

            return Ok("Comedian was update sucessfull");
        }

        /// <summary>
        /// Delete comedian with id
        /// </summary>
        /// <param name="id">Type is a guid</param>
        /// <returns></returns>
        
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteComedian(Guid id)
        {
            BaseResponseDto<ComedianDto> delComedian = await _comedianService.DeleteComedian(id);

            if (!delComedian.HasError)
            {
                return Ok(delComedian.Data);
            }
            else
            {
                return BadRequest(delComedian.Errors);
            }
        }
    }
}