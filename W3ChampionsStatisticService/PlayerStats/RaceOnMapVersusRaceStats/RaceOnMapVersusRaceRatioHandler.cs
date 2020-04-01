﻿using System.Threading.Tasks;
using W3ChampionsStatisticService.MatchEvents;
using W3ChampionsStatisticService.PlayerProfiles;
using W3ChampionsStatisticService.Ports;

namespace W3ChampionsStatisticService.PlayerStats.RaceOnMapVersusRaceStats
{
    public class RaceOnMapVersusRaceRatioHandler : IReadModelHandler
    {
        private readonly IPlayerStatsRepository _playerRepository;

        public RaceOnMapVersusRaceRatioHandler(
            IPlayerStatsRepository playerRepository
            )
        {
            _playerRepository = playerRepository;
        }

        public async Task Update(MatchFinishedEvent nextEvent)
        {
            var dataPlayers = nextEvent.data.players;
            if (dataPlayers.Count == 2)
            {
                var p1 = await _playerRepository.LoadMapAndRaceStat(dataPlayers[0].battleTag)
                         ?? MapAndRaceRatio.Create (dataPlayers[0].battleTag);
                var p2 = await _playerRepository.LoadMapAndRaceStat(dataPlayers[1].battleTag)
                         ?? MapAndRaceRatio.Create(dataPlayers[1].battleTag);

                p1.AddMapWin(dataPlayers[0].won,
                    (Race) dataPlayers[0].raceId,
                    (Race) dataPlayers[1].raceId,
                    nextEvent.data.mapInfo.name);
                p2.AddMapWin(dataPlayers[1].won,
                    (Race) dataPlayers[1].raceId,
                    (Race) dataPlayers[0].raceId,
                    nextEvent.data.mapInfo.name);

                await _playerRepository.UpsertMapAndRaceStat(p1);
                await _playerRepository.UpsertMapAndRaceStat(p2);
            }
        }
    }
}