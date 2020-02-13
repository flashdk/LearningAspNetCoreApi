using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyEvents.Domain.Dtos;
using ComedyEvents.Dto;
using ComedyEvents.Domain.Models;
using ComedyEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComedyEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : Controller
    {
        private readonly IVenueService _venueService;

        public VenuesController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        /// <summary>
        /// Get all venues
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<BaseResponseDto<IEnumerable<VenueDto>>>> GetAllVenues()
        {
            BaseResponseDto<IEnumerable<VenueDto>> venues = await _venueService.GetVenues();

            if (!venues.HasError || venues.Data != null)
            {
                return Ok(venues.Data);
            }
            else if (!venues.HasError || venues.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(venues.Errors);
            }
        }

        /// <summary>
        /// Add new venue in database
        /// </summary>
        /// <param name="venue"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<BaseResponseDto<VenueDto>>> AddVenue(Venue venue)
        {
            BaseResponseDto<VenueDto> newVenue = await _venueService.CreateVenue(venue);

            if (!newVenue.HasError || newVenue.Data != null)
            {
                return Ok(newVenue.Data);
            }
            else if (!newVenue.HasError || newVenue.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(newVenue.Errors);
            }
        }

        /// <summary>
        /// Get single venue by Id
        /// </summary>
        /// <param name="id">Is a guid</param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<VenueDto>> GetById([FromRoute]string id)
        {
            Guid _id = Guid.Parse(id);

            BaseResponseDto<VenueDto> venue = await _venueService.GetVenueById(_id);

            if (!venue.HasError || venue.Data != null)
            {
                return Ok(venue.Data);
            }
            else if (!venue.HasError || venue.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(venue.Errors);
            }
        }

        /// <summary>
        /// Update venue
        /// </summary>
        /// <param name="id">Is a guid</param>
        /// <param name="venue"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateVenue([FromRoute]string id, Venue venue)
        {
            Guid _id = Guid.Parse(id);
            BaseResponseDto<VenueDto> UpdateVenue = await _venueService.UpDateVenue(_id, venue);

            if (!UpdateVenue.HasError)
            {
                return Ok("venue was update sucessfull");
            }
            else
            {
                return BadRequest(UpdateVenue.Errors);
            }
        }

        /// <summary>
        /// Delete venue by id
        /// </summary>
        /// <param name="id">Is a Guid</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteVenue(Guid id)
        {
            BaseResponseDto<VenueDto> delVenue = await _venueService.DeleteVenue(id);

            if (!delVenue.HasError)
            {
                return Ok(delVenue.Data);
            }
            else
            {
                return BadRequest(delVenue.Errors);
            }
        }


    }
}