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
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Get all event
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<BaseResponseDto<IEnumerable<EventDto>>>> GetAllEvents()
        {
            BaseResponseDto<IEnumerable<EventDto>> events = await  _eventService.GetEvents();

            if (!events.HasError || events.Data != null)
            {
                return Ok(events.Data);
            }
            else if (!events.HasError || events.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(events.Errors);
            }
        }

        /// <summary>
        /// Create new Event
        /// </summary>
        /// <param name="newEvent"></param>
        /// <returns></returns>

        //[HttpPost]
        //public async Task<ActionResult<BaseResponseDto<EventDto>>> AddEvent(Event newEvent)
        //{

        //    BaseResponseDto<EventDto> eventAdded = await _eventService.CreateEvent(newEvent);

        //    if (!eventAdded.HasError || eventAdded.Data != null)
        //    {
        //        return Ok(eventAdded.Data);
        //    }
        //    else if (!eventAdded.HasError || eventAdded.Data == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return BadRequest(eventAdded.Errors);
        //    }
        //}

        ///// <summary>
        ///// Get Event by Id
        ///// </summary>
        ///// <param name="id">Is a guid</param>
        ///// <returns></returns>
        //[HttpGet("{id}")]
        //public async Task<ActionResult<EventDto>> GetById([FromRoute]string id)
        //{
        //    Guid _id = Guid.Parse(id);

        //    BaseResponseDto<EventDto> eventData = await _eventService.GetEventById(_id);

        //    if (!eventData.HasError || eventData.Data != null)
        //    {
        //        return Ok(eventData.Data);
        //    }
        //    else if (!eventData.HasError || eventData.Data == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return BadRequest(eventData.Errors);
        //    }
        //}

        ///// <summary>
        ///// Delete event
        ///// </summary>
        ///// <param name="id">Is a guid</param>
        ///// <returns></returns>
        //[HttpDelete]
        //public async Task<ActionResult<string>> DeleteEvent(Guid id)
        //{
        //    BaseResponseDto<EventDto> delVenue = await _eventService.DeleteEvent(id);

        //    if (!delVenue.HasError)
        //    {
        //        return Ok(delVenue.Data);
        //    }
        //    else
        //    {
        //        return BadRequest(delVenue.Errors);
        //    }
        //}

        ///// <summary>
        ///// Update event
        ///// </summary>
        ///// <param name="id">Is a guid</param>
        ///// <param name="eventData">is json data</param>
        ///// <returns></returns>
        //[HttpPut("{id}")]
        //public async Task<ActionResult<string>> UpdateEvent([FromRoute]string id, Event eventData)
        //{
        //    Guid _id = Guid.Parse(id);
        //    BaseResponseDto<EventDto> UpdateEvent = await _eventService.UpDateEvent(_id, eventData);

        //    if (!UpdateEvent.HasError)
        //    {
        //        return Ok("Event was update sucessfull");
        //    }
        //    else
        //    {
        //        return BadRequest(UpdateEvent.Errors);
        //    }
        //}

    }
}