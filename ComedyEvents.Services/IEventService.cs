using ComedyEvents.Domain.Dtos;
using ComedyEvents.Dto;
using ComedyEvents.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyEvents.Services
{
    public interface IEventService
    {
        Task<BaseResponseDto<EventDto>> CreateEvent(Event newEvent);
        Task<BaseResponseDto<IEnumerable<EventDto>>> GetEvents();
        Task<BaseResponseDto<EventDto>> GetEventById(Guid Id);
        Task<BaseResponseDto<IEnumerable<EventDto>>> GetEventByDate(DateTime date);
        Task<BaseResponseDto<EventDto>> UpDateEvent(Guid eventId, Event eventData);
        Task<BaseResponseDto<EventDto>> DeleteEvent(Guid eventId);
    }
}
