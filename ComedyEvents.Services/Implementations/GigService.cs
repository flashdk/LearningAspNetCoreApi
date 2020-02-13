using ComedyEvents.Domain.Dtos;
using ComedyEvents.Domain.Models;
using ComedyEvents.Dto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComedyEvents.Services.Implementations
{
    public class GigService : IGigService
    {
        private readonly ILogger<GigService> _logger;
        private readonly IRepository<Gig> _gigRepository;
        public GigService(ILogger<GigService> logger, IRepository<Gig> gigRepository)
        {
            _logger = logger;
            _gigRepository = gigRepository;
        }
        public Task<BaseResponseDto<GigDto>> CreateGig(Gig gig)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseDto<GigDto>> DeleteGig(Guid venueId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseDto<GigDto>> GetGigById(Guid venueId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseDto<IEnumerable<GigDto>>> GetGigs()
        {
            BaseResponseDto<IEnumerable<GigDto>> getGigResponse = new BaseResponseDto<IEnumerable<GigDto>>();
            try
            {
                getGigResponse.Data =
                  (await _gigRepository.GetAllAsync()).Select(g => new GigDto()
                  {
                      Id = g.Id,
                      ComedianId = g.ComedianId,
                      EventId = g.EventId,
                      GigHeadline = g.GigHeadline,
                      GigLengthInMinute = g.GigLengthInMinute,
                      Comedian = g.Comedian,
                      Event = g.Event,
                      CreatedAt = g.CreatedAt.Value,
                      ModifiedAt = g.ModifiedAt.Value,
                  }) ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getGigResponse.Errors.Add(ex.Message);
            }

            return getGigResponse;
        }

        public Task<BaseResponseDto<GigDto>> UpDateGig(Guid venueId, Venue venue)
        {
            throw new NotImplementedException();
        }
    }
}
