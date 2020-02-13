using ComedyEvents.Domain.Dtos;
using ComedyEvents.Dto;
using ComedyEvents.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComedyEvents.Services;

using System.Linq;

namespace ComedyEvents.Services.Implementations
{
    public class ComedianService : IComedianService
    {
        private readonly ILogger<ComedianService> _logger;
        private readonly IRepository<Comedian> _comedianRepository;

        public ComedianService(ILogger<ComedianService> logger, IRepository<Comedian> comedianRepository)
        {
            _logger = logger;
            _comedianRepository = comedianRepository;
        }

        public async Task<BaseResponseDto<ComedianDto>> GetAsync(Guid Id)
        {
            BaseResponseDto<ComedianDto> getComedianResponse = new BaseResponseDto<ComedianDto>();

            try
            {
                Comedian comedian = await _comedianRepository.GetAsync(Id);

                if (comedian != null)
                {
                    getComedianResponse.Data = new ComedianDto
                    {
                        FirstName = comedian.FirstName,
                        LastName = comedian.LastName,
                        ContactPhone = comedian.ContactPhone,
                    };
                }
                else
                {
                    getComedianResponse.Errors.Add("Comedian not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getComedianResponse.Errors.Add(ex.Message);
            }

            return getComedianResponse;
        }

        public Task<BaseResponseDto<ComedianDto[]>> GetComedianByEvent(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseDto<ComedianDto>> UpDateComedian(Guid comedianId, Comedian comedian)
        {
            BaseResponseDto<ComedianDto> getComedianResponse = new BaseResponseDto<ComedianDto>();
            try
            {
                if (comedianId != null)
                {
                    Comedian oldComedian = await _comedianRepository.GetAsync(comedianId);
                    if(oldComedian != null)
                    {
                        oldComedian.FirstName = comedian.FirstName;
                        oldComedian.LastName = comedian.LastName;
                        oldComedian.ContactPhone = comedian.ContactPhone;
                        oldComedian.ModifiedAt = DateTime.Now;

                        //var comedianUpdate = _mapper.Map(comedian, oldComedian);
                        await _comedianRepository.UpdateAsync(oldComedian);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    getComedianResponse.Errors.Add("Comedian can't be update.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getComedianResponse.Errors.Add(ex.Message);
            }

            return getComedianResponse;
        }

        public async Task<BaseResponseDto<ComedianDto>> DeleteComedian(Guid comedianId)
        {
            BaseResponseDto<ComedianDto> getComedianResponse = new BaseResponseDto<ComedianDto>();
            try
            {
                if (comedianId != null)
                {
                    Comedian comedian = await _comedianRepository.GetAsync(comedianId);
                    await _comedianRepository.DeleteAsync(comedian);
                }
                else
                {
                    getComedianResponse.Errors.Add("Comedian can't be delete.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getComedianResponse.Errors.Add(ex.Message);
            }

            return getComedianResponse;
        }

        public async Task<BaseResponseDto<IEnumerable<ComedianDto>>> GetComedians()
          {
            BaseResponseDto<IEnumerable<ComedianDto>> getComedianResponse = new BaseResponseDto<IEnumerable<ComedianDto>>();
            try
              {
                  getComedianResponse.Data =
                    (await _comedianRepository.GetAllAsync()).Select(c => new ComedianDto() {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        ContactPhone = c.ContactPhone,
                        CreatedAt = c.CreatedAt.Value,
                        ModifiedAt = c.ModifiedAt.Value
                  });
                 
              }
              catch (Exception ex)
              {
                  _logger.LogError(ex, ex.Message);
                  getComedianResponse.Errors.Add(ex.Message);
              }

              return getComedianResponse;
          }

        public async Task<BaseResponseDto<ComedianDto>> CreateComedian(Comedian comedian)
        {
            BaseResponseDto<ComedianDto> getComedianResponse = new BaseResponseDto<ComedianDto>();
            try
            {
                await _comedianRepository.CreateAsync(comedian);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getComedianResponse.Errors.Add(ex.Message);
            }
            return getComedianResponse;
        }
    }
}
