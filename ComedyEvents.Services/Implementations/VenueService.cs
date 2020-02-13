using AutoMapper;
using ComedyEvents.Domain.Dtos;
using ComedyEvents.Dto;
using ComedyEvents.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Services.Implementations
{
    public class VenueService : IVenueService
    {
        private readonly ILogger<VenueService> _logger;
        private readonly IRepository<Venue> _venueRepository;

        public VenueService(ILogger<VenueService> logger, IRepository<Venue> venueRepository)
        {
            _logger = logger;
            _venueRepository = venueRepository;
        }

        public async Task<BaseResponseDto<VenueDto>> CreateVenue(Venue venue)
        {
            BaseResponseDto<VenueDto> getVenueResponse = new BaseResponseDto<VenueDto>();
            try
            {
                await _venueRepository.CreateAsync(venue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getVenueResponse.Errors.Add(ex.Message);
            }
            return getVenueResponse;
        }

        public async Task<BaseResponseDto<VenueDto>> DeleteVenue(Guid venueId)
        {
            BaseResponseDto<VenueDto> getVenueResponse = new BaseResponseDto<VenueDto>();
            try
            {
                if (venueId != null)
                {
                    Venue venue = await _venueRepository.GetAsync(venueId);
                    await _venueRepository.DeleteAsync(venue);
                }
                else
                {
                    getVenueResponse.Errors.Add("Venue can't be delete.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getVenueResponse.Errors.Add(ex.Message);
            }

            return getVenueResponse;
        }

        public async Task<BaseResponseDto<VenueDto>> GetVenueById(Guid venueId)
        {
            BaseResponseDto<VenueDto> getVenueResponse = new BaseResponseDto<VenueDto>();

            try
            {
                Venue venue = await _venueRepository.GetAsync(venueId);

                if (venue != null)
                {
                    getVenueResponse.Data = new VenueDto
                    {
                        Id = venue.Id,              
                        VenueName = venue.VenueName,
                        City = venue.City,
                        State = venue.State,
                        Seating = venue.Seating,
                        ServesAlcohol = venue.ServesAlcohol.Value,
                        Street = venue.Street,
                        ZipCode = venue.ZipCode,
                    };
                }
                else
                {
                    getVenueResponse.Errors.Add("Venue not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getVenueResponse.Errors.Add(ex.Message);
            }

            return getVenueResponse;
        }

        public async Task<BaseResponseDto<IEnumerable<VenueDto>>> GetVenues()
        {
            BaseResponseDto<IEnumerable<VenueDto>> getVenueResponse = new BaseResponseDto<IEnumerable<VenueDto>>();
            try
            {
                getVenueResponse.Data =
                  (await _venueRepository.GetAllAsync()).Select(v => new VenueDto()
                  {
                      Id = v.Id,
                      VenueName = v.VenueName,
                      City = v.City,
                      State = v.State,
                      Seating = v.Seating,
                      ServesAlcohol = v.ServesAlcohol.Value,
                      Street = v.Street,
                      ZipCode = v.ZipCode,
                      CreatedAt = v.CreatedAt.Value,
                      ModifiedAt = v.ModifiedAt.Value,
                  });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getVenueResponse.Errors.Add(ex.Message);
            }

            return getVenueResponse;
        }

        public async Task<BaseResponseDto<VenueDto>> UpDateVenue(Guid venueId, Venue venue)
        {
            BaseResponseDto<VenueDto> getVenueResponse = new BaseResponseDto<VenueDto>();
            try
            {
                if (venueId != null)
                {
                    Venue oldVenue = await _venueRepository.GetAsync(venueId);
                    if (oldVenue != null)
                    {
                        oldVenue.VenueName = venue.VenueName;
                        oldVenue.Seating = venue.Seating;
                        oldVenue.City = venue.City;
                        oldVenue.ServesAlcohol = venue.ServesAlcohol;
                        oldVenue.State = venue.State;
                        oldVenue.ZipCode = venue.ZipCode;
                        oldVenue.Street = venue.Street;
                        oldVenue.ModifiedAt = DateTime.UtcNow;

                        await _venueRepository.UpdateAsync(oldVenue);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    getVenueResponse.Errors.Add("Venue can't be update.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getVenueResponse.Errors.Add(ex.Message);
            }

            return getVenueResponse;
        }

    }
}
