using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Infrastructure;

using System.Reflection;


namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IMediator _mediator;

        public AppDbContext(DbContextOptions<AppDbContext> options , IMediator mediator): base(options)    
        {
            _mediator = mediator;
        }
      
        public DbSet<Campaign> Campaigns => Set<Campaign>();

        public DatabaseFacade database => Database;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Campaign>().HasNoKey();

            base.OnModelCreating(builder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //TODO: dispatching domain events
            return await base.SaveChangesAsync(cancellationToken);
        }
        
    }
}
