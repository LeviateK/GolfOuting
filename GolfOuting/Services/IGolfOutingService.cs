using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfOuting.Models;
using Microsoft.EntityFrameworkCore;
using GolfOuting.Data;
using GolfOuting.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Data.Common;

namespace GolfOuting.Services
{
    public interface IGolfOutingService
    {
        #region Player
        Task<List<Player>> GetPlayersAsync();
        Task<Player> GetPlayerAsync(int id);
        Task<Player> AddAsync(Player player);
        Task<Player> UpdateAsync(Player player);
        Task<Player> DeletePlayerAsync(int id);
        #endregion

        #region Teams
        Task<List<Team>> GetTeamsAsync();
        Task<Team> GetTeamAsync(int id);
        Task<Team> AddAsync(Team team);
        Task<Team> UpdateAsync(Team team);
        Task<Team> DeleteTeamAsync(int id);
        #endregion

        #region TeamPlayer
        Task<List<TeamPlayer>> GetTeamPlayersAsync();
        Task<TeamPlayer> GetTeamPlayerAsync(int id);
        Task<TeamPlayer> AddAsync(TeamPlayer teamPlayer);
        Task<TeamPlayer> UpdateAsync(TeamPlayer teamPlayer);
        Task<TeamPlayer> DeleteTeamPlayerAsync(int id);
        #endregion

        #region HoleScore
        Task<List<HoleScore>> GetHoleScoresAsync();
        Task<List<HoleScore>> GetHoleScoresAsync(int outingTeamID);
        Task<HoleScore> GetHoleScoreAsync(int id);
        Task<HoleScore> AddAsync(HoleScore holeScore);
        Task<HoleScore> UpdateAsync(HoleScore holeScore);
        Task<HoleScore> DeleteHoleScoreAsync(int id);
        #endregion

        #region scorecard

        Task<bool> GenerateEmptyScorecard(Course course, OutingTeam outingTeam);
        Task<List<CompleteScorecard>> GenerateCompleteScorecard(int outingID);

        #endregion
        #region Outing
        Task<List<Outing>> GetOutingsAsync();

        #endregion

        #region OutingTeam
        Task<List<OutingTeam>> GetOutingTeamsAsync();
        Task<OutingTeam> GetOutingTeamAsync(int id);
        Task<OutingTeam> AddAsync(OutingTeam outingTeam);
        Task<OutingTeam> UpdateAsync(OutingTeam outingTeam);
        Task<OutingTeam> DeleteOutingTeamAsync(int id);
        #endregion

        

        #region Course
        Task<List<Course>> GetCoursesAsync();
        #endregion
    }

    public class GolfOutingService : IGolfOutingService
    {
        #region DB
        private readonly GolfOutingContext _dbContext;

        public GolfOutingService(GolfOutingContext dbContext, IServiceScopeFactory _serviceScopeFactory)
        {
            _dbContext = dbContext;

        }
        #endregion
        #region Player
        public async Task<List<Player>> GetPlayersAsync()
        {
            List<Player> players = await _dbContext.Player.ToListAsync();
            return players;
        }
        public async Task<Player> GetPlayerAsync(int id)
        {
            Player player = await _dbContext.Player.FindAsync(id);
            return player;
        }
        public async Task<Player> AddAsync(Player player)
        {
            _dbContext.Player.Add(player);
            await _dbContext.SaveChangesAsync();
            return player;
        }
        public async Task<Player> UpdateAsync(Player player)
        {
            _dbContext.Entry(player).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return player;
        }
        public async Task<Player> DeletePlayerAsync(int id)
        {
            Player player = await _dbContext.Player.FindAsync(id);
            _dbContext.Player.Remove(player);
            await _dbContext.SaveChangesAsync();
            return player;
        }

        #endregion



        #region Team
        public async Task<List<Team>> GetTeamsAsync()
        {
            List<Team> teams = await _dbContext.Team.ToListAsync();
            return teams;
        }
        public async Task<Team> GetTeamAsync(int id)
        {
            Team team = await _dbContext.Team.FindAsync(id);
            return team;
        }
        public async Task<Team> AddAsync(Team team)
        {
            _dbContext.Team.Add(team);
            await _dbContext.SaveChangesAsync();
            return team;
        }
        public async Task<Team> UpdateAsync(Team team)
        {
            _dbContext.Entry(team).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return team;
        }
        public async Task<Team> DeleteTeamAsync(int id)
        {
            Team team = await _dbContext.Team.FindAsync(id);
            _dbContext.Team.Remove(team);
            await _dbContext.SaveChangesAsync();
            return team;
        }

        #endregion

        #region OutingTeam
        public async Task<List<OutingTeam>> GetOutingTeamsAsync()
        {
            List<OutingTeam> outingTeams = await _dbContext.OutingTeam.ToListAsync();
            return outingTeams;
        }
        public async Task<OutingTeam> GetOutingTeamAsync(int id)
        {
            OutingTeam outingTeam = await _dbContext.OutingTeam.FindAsync(id);
            return outingTeam;
        }
        public async Task<OutingTeam> AddAsync(OutingTeam outingTeam)
        {
            _dbContext.OutingTeam.Add(outingTeam);
            await _dbContext.SaveChangesAsync();
            return outingTeam;
        }
        public async Task<OutingTeam> UpdateAsync(OutingTeam outingTeam)
        {
            _dbContext.Entry(outingTeam).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return outingTeam;
        }
        public async Task<OutingTeam> DeleteOutingTeamAsync(int id)
        {
            OutingTeam outingTeam = await _dbContext.OutingTeam.FindAsync(id);
            _dbContext.OutingTeam.Remove(outingTeam);
            await _dbContext.SaveChangesAsync();
            return outingTeam;
        }

        #endregion

        #region TeamPlayer
        public async Task<List<TeamPlayer>> GetTeamPlayersAsync()
        {
            List<TeamPlayer> teamPlayers = await _dbContext.TeamPlayer.ToListAsync();
            return teamPlayers;
        }
        public async Task<TeamPlayer> GetTeamPlayerAsync(int id)
        {
            TeamPlayer teamPlayer = await _dbContext.TeamPlayer.FindAsync(id);
            return teamPlayer;
        }
        public async Task<TeamPlayer> AddAsync(TeamPlayer teamPlayer)
        {
            _dbContext.TeamPlayer.Add(teamPlayer);
            await _dbContext.SaveChangesAsync();
            return teamPlayer;
        }
        public async Task<TeamPlayer> UpdateAsync(TeamPlayer teamPlayer)
        {
            _dbContext.Entry(teamPlayer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return teamPlayer;
        }
        public async Task<TeamPlayer> DeleteTeamPlayerAsync(int id)
        {
            TeamPlayer teamPlayer = await _dbContext.TeamPlayer.FindAsync(id);
            _dbContext.TeamPlayer.Remove(teamPlayer);
            await _dbContext.SaveChangesAsync();
            return teamPlayer;
        }

        #endregion


        #region HoleScore
        public async Task<List<HoleScore>> GetHoleScoresAsync()
        {
            List<HoleScore> holeScores = await _dbContext.HoleScore
                .Include(h => h.Hole)
                    .ThenInclude(h => h.Course)
                .Include(h => h.OutingTeam)
                    .ThenInclude(h => h.Outing)
                        .ThenInclude(h => h.Year)
                .Include(h => h.OutingTeam)
                    .ThenInclude(h => h.Team)
                .ToListAsync();
            return holeScores;
        }
        public async Task<List<HoleScore>> GetHoleScoresAsync(int outingTeamID)
        {
            List<HoleScore> holeScores = await _dbContext.HoleScore
                .Include(h => h.Hole)
                    .ThenInclude(h => h.Course)
                .Include(h => h.OutingTeam)
                    .ThenInclude(h => h.Outing)
                        .ThenInclude(h=>h.Year)
                .Include(h => h.OutingTeam)
                    .ThenInclude(h => h.Team)
                .Where(h=>h.OutingTeamID == outingTeamID)
                .ToListAsync();
            return holeScores;
        }
        public async Task<HoleScore> GetHoleScoreAsync(int id)
        {
            HoleScore holeScore = await _dbContext.HoleScore
                .Include(h => h.Hole)
                    .ThenInclude(h => h.Course)
                .Include(h=>h.OutingTeam)
                    .ThenInclude(h=>h.Outing)
                .Include(h => h.OutingTeam)
                    .ThenInclude(h => h.Team)
                .FirstOrDefaultAsync(h => id == h.HoleScoreID);
            return holeScore;
        }
        public async Task<HoleScore> AddAsync(HoleScore holeScore)
        {
            _dbContext.HoleScore.Add(holeScore);
            await _dbContext.SaveChangesAsync();
            return holeScore;
        }
        public async Task<HoleScore> UpdateAsync(HoleScore holeScore)
        {
            _dbContext.Entry(holeScore).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return holeScore;
        }
        public async Task<HoleScore> DeleteHoleScoreAsync(int id)
        {
            HoleScore holeScore = await _dbContext.HoleScore.FindAsync(id);
            _dbContext.HoleScore.Remove(holeScore);
            await _dbContext.SaveChangesAsync();
            return holeScore;
        }

        #endregion

        #region scorecard

        public async Task<bool> GenerateEmptyScorecard(Course course, OutingTeam outingTeam)
        {
            foreach (Hole hole in course.Holes)
            {
                HoleScore holeScore = new HoleScore
                {
                    OutingTeamID = outingTeam.OutingTeamID,
                    HoleID = hole.HoleID,
                    Score = 0
                };
                await AddAsync(holeScore);
            }
            return true;
        }

        public async Task<List<CompleteScorecard>> GenerateCompleteScorecard(int outingID)
        {
            List<HoleScore> holeScores = await GetHoleScoresAsync();
            List<CompleteScorecard> completeScorecards = new List<CompleteScorecard>();
            var outingScoresGrouped = holeScores.Where(h => h.OutingTeam.OutingID == outingID).OrderBy(h=>h.Hole.HoleNumber).GroupBy(h=>h.OutingTeam).ToList();
            foreach (var item in outingScoresGrouped)
            {
                CompleteScorecard completeScorecard = new CompleteScorecard
                {
                    TeamName = item.Key.Team.TeamName,
                    InSkins = item.Key.Team.Skins,
                    Hole1Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 1).First().Score,
                    Hole2Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 2).First().Score,
                    Hole3Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 3).First().Score,
                    Hole4Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 4).First().Score,
                    Hole5Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 5).First().Score,
                    Hole6Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 6).First().Score,
                    Hole7Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 7).First().Score,
                    Hole8Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 8).First().Score,
                    Hole9Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 9).First().Score,
                    Hole10Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 10).First().Score,
                    Hole11Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 11).First().Score,
                    Hole12Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 12).First().Score,
                    Hole13Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 13).First().Score,
                    Hole14Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 14).First().Score,
                    Hole15Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 15).First().Score,
                    Hole16Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 16).First().Score,
                    Hole17Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 17).First().Score,
                    Hole18Score = item.Key.HoleScores.Where(h => h.Hole.HoleNumber == 18).First().Score,
                    RoundScore = item.Key.HoleScores.Sum(h=>h.Score)
                };
                completeScorecards.Add(completeScorecard);
                
            }
            int hole1LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole1Score);
            int hole1LowScoreCount = completeScorecards.Count(s => s.Hole1Score == hole1LowScore && s.InSkins);

            int hole2LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole2Score);
            int hole2LowScoreCount = completeScorecards.Count(s => s.Hole2Score == hole2LowScore && s.InSkins);

            int hole3LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole3Score);
            int hole3LowScoreCount = completeScorecards.Count(s => s.Hole3Score == hole3LowScore && s.InSkins);

            int hole4LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole4Score);
            int hole4LowScoreCount = completeScorecards.Count(s => s.Hole4Score == hole4LowScore && s.InSkins);

            int hole5LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole5Score);
            int hole5LowScoreCount = completeScorecards.Count(s => s.Hole5Score == hole5LowScore && s.InSkins);

            int hole6LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole6Score);
            int hole6LowScoreCount = completeScorecards.Count(s => s.Hole6Score == hole6LowScore && s.InSkins);

            int hole7LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole7Score);
            int hole7LowScoreCount = completeScorecards.Count(s => s.Hole7Score == hole7LowScore && s.InSkins);

            int hole8LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole8Score);
            int hole8LowScoreCount = completeScorecards.Count(s => s.Hole8Score == hole8LowScore && s.InSkins);

            int hole9LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole9Score);
            int hole9LowScoreCount = completeScorecards.Count(s => s.Hole9Score == hole9LowScore && s.InSkins);

            int hole10LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole10Score);
            int hole10LowScoreCount = completeScorecards.Count(s => s.Hole10Score == hole10LowScore && s.InSkins);

            int hole11LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole11Score);
            int hole11LowScoreCount = completeScorecards.Count(s => s.Hole11Score == hole11LowScore && s.InSkins);

            int hole12LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole12Score);
            int hole12LowScoreCount = completeScorecards.Count(s => s.Hole12Score == hole12LowScore && s.InSkins);

            int hole13LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole13Score);
            int hole13LowScoreCount = completeScorecards.Count(s => s.Hole13Score == hole13LowScore && s.InSkins);

            int hole14LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole14Score);
            int hole14LowScoreCount = completeScorecards.Count(s => s.Hole14Score == hole14LowScore && s.InSkins);

            int hole15LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole15Score);
            int hole15LowScoreCount = completeScorecards.Count(s => s.Hole15Score == hole15LowScore && s.InSkins);

            int hole16LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole16Score);
            int hole16LowScoreCount = completeScorecards.Count(s => s.Hole16Score == hole16LowScore && s.InSkins);

            int hole17LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole17Score);
            int hole17LowScoreCount = completeScorecards.Count(s => s.Hole17Score == hole17LowScore && s.InSkins);

            int hole18LowScore = completeScorecards.Where(s => s.InSkins).Min(s => s.Hole18Score);
            int hole18LowScoreCount = completeScorecards.Count(s => s.Hole18Score == hole18LowScore && s.InSkins);
            


            // we got skins, loop through and update
            foreach (CompleteScorecard cs1 in completeScorecards)
                {
                    if (cs1.Hole1Score == hole1LowScore && hole1LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole1Skin = true;
                    }
                    if (cs1.Hole2Score == hole2LowScore && hole2LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole2Skin = true;
                    }
                    if (cs1.Hole3Score == hole3LowScore && hole3LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole3Skin = true;
                    }
                    if (cs1.Hole4Score == hole4LowScore && hole4LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole4Skin = true;
                    }
                    if (cs1.Hole5Score == hole5LowScore && hole5LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole5Skin = true;
                    }
                    if (cs1.Hole6Score == hole6LowScore && hole6LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole6Skin = true;
                    }
                    if (cs1.Hole7Score == hole7LowScore && hole7LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole7Skin = true;
                    }
                    if (cs1.Hole8Score == hole8LowScore && hole8LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole8Skin = true;
                    }
                    if (cs1.Hole9Score == hole9LowScore && hole9LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole9Skin = true;
                    }
                    if (cs1.Hole10Score == hole10LowScore && hole10LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole10Skin = true;
                    }
                    if (cs1.Hole11Score == hole11LowScore && hole11LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole11Skin = true;
                    }
                    if (cs1.Hole12Score == hole12LowScore && hole12LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole12Skin = true;
                    }
                    if (cs1.Hole13Score == hole13LowScore && hole13LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole13Skin = true;
                    }
                    if (cs1.Hole14Score == hole14LowScore && hole14LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole14Skin = true;
                    }
                    if (cs1.Hole15Score == hole15LowScore && hole15LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole15Skin = true;
                    }
                    if (cs1.Hole16Score == hole16LowScore && hole16LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole16Skin = true;
                    }
                    if (cs1.Hole17Score == hole17LowScore && hole17LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole17Skin = true;
                    }
                    if (cs1.Hole18Score == hole18LowScore && hole18LowScoreCount == 1 && cs1.InSkins)
                    {
                        cs1.Hole18Skin = true;
                    }
                }
            return completeScorecards;

        }

        #endregion

        #region Outing
        public async Task<List<Outing>> GetOutingsAsync()
        {
            List<Outing> outings = await _dbContext.Outing
                .Include(o=>o.Course)
                    .ThenInclude(o=>o.Holes)
                .Include(o=>o.Year)
                .Include(o=>o.OutingTeams)
                    .ThenInclude(o=>o.Team)
                        .ThenInclude(o=>o.TeamPlayers)
                            .ThenInclude(o=>o.Player)
                .Include(o => o.OutingTeams)
                    .ThenInclude(o=>o.HoleScores)
                .ToListAsync();
            return outings;
        }
        #endregion

        #region Course
        public async Task<List<Course>> GetCoursesAsync()
        {
            List<Course> courses = await _dbContext.Course
                .Include(o => o.Holes)
                .ToListAsync();
            return courses;
        }

        #endregion
    }
}
