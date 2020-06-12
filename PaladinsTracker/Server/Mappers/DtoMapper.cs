using System.Collections.Generic;
using AutoMapper;
using HiRezApi.Common.Models;
using PaladinsTracker.Shared.Models.Dto;

namespace PaladinsTracker.Server.Mappers
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Player, PlayerDto>()
                .ForMember(d => d.MatchHistory, a => a.Ignore());
            CreateMap<RankedConquest, RankedConquestDto>();
            CreateMap<MatchHistory, MatchHistoryDto>();
            CreateMap<IEnumerable<MatchHistory>, PlayerDto>(MemberList.Source);
        }
    }
}