using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using W3C.Domain.CommonValueObjects;
using W3ChampionsStatisticService.W3ChampionsStats.DistinctPlayersPerDays;
using W3ChampionsStatisticService.W3ChampionsStats.GameLengths;
using W3ChampionsStatisticService.W3ChampionsStats.GamesPerDays;
using W3ChampionsStatisticService.W3ChampionsStats.HeroPlayedStats;
using W3ChampionsStatisticService.W3ChampionsStats.HeroWinrate;
using W3ChampionsStatisticService.W3ChampionsStats.HourOfPlay;
using W3ChampionsStatisticService.W3ChampionsStats.MapsPerSeasons;
using W3ChampionsStatisticService.W3ChampionsStats.OverallRaceAndWinStats;

namespace W3ChampionsStatisticService.Ports
{
    public interface IW3StatsRepo
    {
        Task<List<OverallRaceAndWinStat>> LoadRaceVsRaceStats();
        Task<OverallRaceAndWinStat> LoadRaceVsRaceStat(int mmrRange);
        Task Save(OverallRaceAndWinStat stat);
        Task<GamesPerDay> LoadGamesPerDay(DateTime date, GameMode matchGameMode, GateWay matchGateway);
        Task Save(List<GamesPerDay> stat);
        Task<GameLengthStat> LoadGameLengths();
        Task Save(GameLengthStat stat);
        Task<DistinctPlayersPerDay> LoadPlayersPerDay(DateTime date);
        Task Save(DistinctPlayersPerDay stat);
        Task<List<DistinctPlayersPerDay>> LoadPlayersPerDayBetween(DateTimeOffset from, DateTimeOffset to);
        Task<List<List<GameDayGroup>>> LoadGamesPerDayBetween(DateTimeOffset from, DateTimeOffset to);
        Task<HourOfPlayStat> LoadHourOfPlay();
        Task Save(HourOfPlayStat stat);
        Task<HeroPlayedStat> LoadHeroPlayedStat();
        Task Save(HeroPlayedStat stat);
        Task<OverallHeroWinRatePerHero> LoadHeroWinrate(string heroComboId);
        Task<List<OverallHeroWinRatePerHero>> LoadHeroWinrateLike(string heroComboId);
        Task Save(OverallHeroWinRatePerHero overallHeroWinrate);
        Task<MapsPerSeason> LoadMapsPerSeason(int matchSeason);
        Task Save(MapsPerSeason mapsPerSeason);
        Task<List<MapsPerSeason>> LoadMatchesOnMap();
    }
}