using ComedyEvents.Domain.Dtos;
using ComedyEvents.Dto;
using ComedyEvents.Domain.Models;
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

        public EventService(ILogger<EventService> logger, IRepository<Event> eventRepository)
        {
            _logger = logger;
            _EventRepository = eventRepository;
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

        public async Task<BaseResponseDto<EventDto>> DeleteEvent(Guid eventId)
        {
            BaseResponseDto<EventDto> getEventResponse = new BaseResponseDto<EventDto>();
            try
            {
                if (eventId != null)
                {
                    Event eventDate = await _EventRepository.GetAsync(eventId);
                    await _EventRepository.DeleteAsync(eventDate);
                }
                else
                {
                    getEventResponse.Errors.Add("Event can't be delete.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getEventResponse.Errors.Add(ex.Message);
            }

            return getEventResponse;
        }

        public async Task<BaseResponseDto<IEnumerable<EventDto>>> GetEventByDate(DateTime date)
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
                      CreatedAt = e.CreatedAt.Value,
                      ModifiedAt = e.ModifiedAt.Value,
                  });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getEventResponse.Errors.Add(ex.Message);
            }

            return getEventResponse;
        }

        public async Task<BaseResponseDto<EventDto>> GetEventById(Guid Id)
        {
            BaseResponseDto<EventDto> getEventResponse = new BaseResponseDto<EventDto>();

            try
            {
                Event eventData = await _EventRepository.GetAsync(Id);

                if (eventData != null)
                {
                    getEventResponse.Data = new EventDto
                    {
                        Id = eventData.Id,
                        EnventName = eventData.EnventName,
                        EventDate = eventData.EventDate,
                        VenueId = eventData.VenueId,
                        //Venue = eventData.Venue,
                        //Gig = eventData.Gig,
                        CreatedAt = eventData.CreatedAt.Value,
                        ModifiedAt = eventData.ModifiedAt.Value,
                    };
                }
                else
                {
                    getEventResponse.Errors.Add("Event not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getEventResponse.Errors.Add(ex.Message);
            }

            return getEventResponse;
        }

        public async Task<BaseResponseDto<IEnumerable<EventDto>>> GetEvents()
        {
            
            BaseResponseDto<IEnumerable<EventDto>> getEventResponse = new BaseResponseDto<IEnumerable<EventDto>>();
            try
            {
                //string[] includes = new String [1]{"Gig"};
                getEventResponse.Data =
                  (await _EventRepository.GetAllAsync()).Select(e => new EventDto()
                  {
                      Id = e.Id,
                      VenueId = e.VenueId,
                      EnventName = e.EnventName,
                      EventDate = e.EventDate,
                      Venue = e.Venue,
                      
                      CreatedAt = e.CreatedAt.Value,
                      ModifiedAt = e.ModifiedAt.Value,
                  });
                //getEventResponse.Data.Gig = (await _GigRepository.GetAllAsync()).Where(p => p.EventId == getEventResponse.Data.Id).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getEventResponse.Errors.Add(ex.Message);
            }

            return getEventResponse;
        }

        public async Task<BaseResponseDto<EventDto>> UpDateEvent(Guid eventId, Event eventData)
        {
            BaseResponseDto<EventDto> getEventResponse = new BaseResponseDto<EventDto>();
            try
            {
                if (eventId != null)
                {
                    Event oldEvent = await _EventRepository.GetAsync(eventId);
                    if (oldEvent != null)
                    {
                        oldEvent.EnventName = eventData.EnventName;
                        oldEvent.EventDate = eventData.EventDate;
                        oldEvent.VenueId = eventData.VenueId;

                        oldEvent.ModifiedAt = DateTime.UtcNow;

                        await _EventRepository.UpdateAsync(oldEvent);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    getEventResponse.Errors.Add("Venue can't be update.");
                }
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
