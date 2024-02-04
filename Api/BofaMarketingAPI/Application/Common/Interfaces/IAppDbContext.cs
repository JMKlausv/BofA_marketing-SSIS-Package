using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAppDbContext  
    {
        DatabaseFacade database { get; }
  
        DbSet<Campaign> Campaigns { get; }

Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
