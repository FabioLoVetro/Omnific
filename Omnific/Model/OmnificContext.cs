using System.Collections.Generic;
using System;
using Omnific.Model;
using Microsoft.EntityFrameworkCore;

namespace Omnific.Model
{
    public class OmnificContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public OmnificContext(DbContextOptions<OmnificContext> options) : base(options)
        {
        }
        /// <summary>
        /// Table Users.
        /// contain all the users registerd to the API
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Table FantasyCharacters.
        /// Contains all the FantasyCharacters created by inventors.
        /// </summary>
        public DbSet<FantasyCharacter> FantasyCharacters { get; set; }
        /// <summary>
        /// Table FantasyCharacters.
        /// Contains all the FantasyCharacters created by inventors.
        /// </summary>
        //public DbSet<FantasyAnimal> FantasyAnimals { get; set; }
        /// <summary>
        /// Table Logs
        /// Containg all the logs of the users
        /// </summary>
        public DbSet<Log> Logs { get; set; }
    }
}