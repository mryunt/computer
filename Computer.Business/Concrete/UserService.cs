using Computer.Business.Abstract;
using Computer.DAL.Dtos.User;
using Computer.DAL.Entities;
using Homework.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Computer.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly ComputerDbContext _computerDbContext;
        public UserService(ComputerDbContext computerDbContext)
        {
            _computerDbContext = computerDbContext;
        }
        public async Task<List<GetListUserDto>> GetUserList()
        {
            return await _computerDbContext.Users.Where(p => !p.IsDeleted).Select(p => new GetListUserDto
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname
            }).ToListAsync();
        }
        public async Task<GetUserDto> GetUserById(int id)
        {
            return await _computerDbContext.Users.Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetUserDto
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddUser(AddUserDto addUserDto)
        {
            var newUser = new User
            {
                Name = addUserDto.Name,
                Surname = addUserDto.Surname
            };
            await _computerDbContext.Users.AddAsync(newUser);
            return await _computerDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var currentUser = await _computerDbContext.Users.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentUser != null)
            {
                currentUser.Name = updateUserDto.Name;
                currentUser.Surname = updateUserDto.Surname;
                currentUser.MDate = DateTime.Now;
                _computerDbContext.Users.Update(currentUser);
                return await _computerDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteUser(int id)
        {
            var user = await _computerDbContext.Users.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                user.IsDeleted = true;
                return await _computerDbContext.SaveChangesAsync();
            }
            return -1;
        }
    }
}
