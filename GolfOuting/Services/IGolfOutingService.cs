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
        Task<Player> DeleteLiquidAsync(int id);
        #endregion

        #region Outing
        Task<List<Outing>> GetOutingsAsync();

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
        public async Task<Player> DeleteLiquidAsync(int id)
        {
            Player player = await _dbContext.Player.FindAsync(id);
            _dbContext.Player.Remove(player);
            await _dbContext.SaveChangesAsync();
            return player;
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
