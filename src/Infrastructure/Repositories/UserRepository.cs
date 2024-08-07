﻿using Domain.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal sealed class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public void Insert(User user)
    {
        context.Users.Add(user);
    }

    public async Task<bool> IsEmailUniqueAsync(Domain.Users.Email email)
    {
        return !await context.Users.AnyAsync(u => u.Email == email);
    }
}
