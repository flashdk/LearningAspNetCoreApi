using ComedyEvents.Domain.Dtos;
using ComedyEvents.Domain.Models;
using ComedyEvents.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyEvents.Services
{
    public interface IGigService
    {
        Task<BaseResponseDto<GigDto>> CreateGig(Gig gig);
        Task<BaseResponseDto<GigDto>> GetGigById(Guid venueId);
        Task<BaseResponseDto<IEnumerable<GigDto>>> GetGigs();
        Task<BaseResponseDto<GigDto>> UpDateGig(Guid venueId, Venue venue);
        Task<BaseResponseDto<GigDto>> DeleteGig(Guid venueId);
    }
}
