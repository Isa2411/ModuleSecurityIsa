﻿using System.Data;
using System.Reflection;
using Dapper;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Module = Entity.Model.Security.Module;

namespace Entity.Context
{
    public class ApplicationDBContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public object countrys;

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnsecces, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnsecces, cancellationToken);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(
                this, text, parameters, timeout, type,
                CancellationToken.None);
            var connection = Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(
                this, text, parameters, timeout, type,
                CancellationToken.None);
            var connection = Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }
        public readonly struct DapperEFCoreCommand : IDisposable
        {
            public DapperEFCoreCommand(ApplicationDBContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                    );
            }
            public CommandDefinition Definition { get; }

            public void Dispose() { }
        }

        //security
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<RoleView> RoleViews => Set<RoleView>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<View> Views => Set<View>();
        public DbSet<City> Citys => Set<City>();
        public DbSet<Country> Countrys => Set<Country>();
        public DbSet<State> States => Set<State>();
    }
}
