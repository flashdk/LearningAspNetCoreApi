using ComedyEvents.Domain.Dtos;
using ComedyEvents.Dto;
using ComedyEvents.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyEvents.Services
{
    public interface IVenueService
    {
        Task<BaseResponseDto<VenueDto>> CreateVenue(Venue comedian);
        Task<BaseResponseDto<VenueDto>> GetVenueById(Guid venueId);
        Task<BaseResponseDto<IEnumerable<VenueDto>>> GetVenues();
        Task<BaseResponseDto<VenueDto>> UpDateVenue(Guid venueId, Venue venue);
        Task<BaseResponseDto<VenueDto>> DeleteVenue(Guid venueId);
    }
}
