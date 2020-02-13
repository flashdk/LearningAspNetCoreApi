using System;
using System.Threading.Tasks;
using ComedyEvents.Dto;

using ComedyEvents.Domain.Dtos;
using System.Collections;
using System.Collections.Generic;
using ComedyEvents.Models;

namespace ComedyEvents.Services.Implementations
{
    public interface IComedianService
    {
        Task<BaseResponseDto<ComedianDto>> CreateComedian(Comedian comedian);
        Task<BaseResponseDto<ComedianDto>> GetAsync(Guid comedianId);
        Task<BaseResponseDto<IEnumerable<ComedianDto>>> GetComedians();
        Task<BaseResponseDto<ComedianDto>> UpDateComedian(Guid comedianId, Comedian comedian);
        Task<BaseResponseDto<ComedianDto>> DeleteComedian(Guid comedian);
    }
}
