using AutoMapper;
using ComedyEvents.Domain.Dtos;
using ComedyEvents.Dto;
using ComedyEvents.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComedyEvents.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly ILogger<EventService> _logger;
        private readonly IRepository<Event> _EventRepository;
        private readonly IMapper _mapper;

        public EventService(ILogger<EventService> logger, IRepository<Event> eventRepository, IMapper mapper)
        {
            _logger = logger;
            _EventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponseDto<EventDto>> CreateEvent(Event newEvent)
        {
            BaseResponseDto<EventDto> getEventResponse = new BaseResponseDto<EventDto>();
            try
            {
                await _EventRepository.CreateAsync(newEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getEventResponse.Errors.Add(ex.Message);
            }
            return getEventResponse;
        }

        public Task<BaseResponseDto<IEnumerable<EventDto>>> GetEventByDate()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseDto<EventDto>> GetEventById()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseDto<IEnumerable<EventDto>>> GetEvents()
        {
            BaseResponseDto<IEnumerable<EventDto>> getEventResponse = new BaseResponseDto<IEnumerable<EventDto>>();
            try
            {
                getEventResponse.Data =
                  (await _EventRepository.GetAllAsync()).Select(e => new EventDto()
                  {
                      Id = e.Id,
                      VenueId = e.VenueId,
                      EnventName = e.EnventName,
                      EventDate = e.EventDate,
                      //Venue = e.Venue,
                      //Gigs = e.Gigs,
                      CreatedAt = e.CreatedAt,
                      ModifiedAt = e.ModifiedAt,
                  });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getEventResponse.Errors.Add(ex.Message);
            }

            return getEventResponse;
        }
    }
}
