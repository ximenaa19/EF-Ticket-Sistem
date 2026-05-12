using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class RolePermissionRepository : RepositoryBase<RolePermission>, IRolePermission
{
    public RolePermissionRepository(AppDbContext context)
        : base(context)
    {
    }
}
