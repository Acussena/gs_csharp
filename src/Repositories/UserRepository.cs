using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gs_csharp.src.Data;
using gs_csharp.src.Models;
using gs_csharp.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gs_csharp.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Get(int id)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new Exception("User not found");

            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users
                .Include(u => u.Skills)
                .ToListAsync();
        }

        public async Task<User> Update(User user)
        {
            var existing = await _context.Users
                .Include(u => u.Skills)
                .FirstOrDefaultAsync(x => x.Id == user.Id);

            if (existing == null)
                throw new Exception("User not found");

            existing.Nome = user.Nome;
            existing.Email = user.Email;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
