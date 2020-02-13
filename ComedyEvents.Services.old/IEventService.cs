using ComedyEvents.Domain.Dtos;
using ComedyEvents.Dto;
using ComedyEvents.Models;
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

        Task<BaseResponseDto<EventDto>> GetEventById();

        Task<BaseResponseDto<IEnumerable<EventDto>>> GetEventByDate();
    }
}
