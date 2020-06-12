using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HiRezApi.Paladins;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaladinsTracker.Server.Caching;
using PaladinsTracker.Shared.Models.Dto;

namespace PaladinsTracker.Server.Controllers
{
    [Route("/api/players")]
    public class PlayerController : Controller
    {
        private readonly IPaladinsApiClient _paladinsApiClient;
        private readonly IMapper _mapper;

        public PlayerController(IPaladinsApiClient paladinsApiClient, IMapper mapper)
        {
            _paladinsApiClient = paladinsApiClient;
            _mapper = mapper;
        }

        [HttpGet]
        [Cache(600)]
        [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPlayerByName(string name)
        {
            var cancellationToken = new CancellationToken();
            var playerAsync = _paladinsApiClient.GetPlayerAsync(name, cancellationToken);
            var matchHistoryAsync = _paladinsApiClient.GetMatchHistoryAsync(name, cancellationToken);
            await Task.WhenAll(playerAsync, matchHistoryAsync);

            var player = _mapper.Map<PlayerDto>(playerAsync.Result);
            var matches = _mapper.Map<IList<MatchHistoryDto>>(matchHistoryAsync.Result);

            player.MatchHistory = matches;
            return Ok(player);
        }
    }
}