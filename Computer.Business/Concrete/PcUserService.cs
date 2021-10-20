using Computer.Business.Abstract;
using Computer.DAL.Dtos.PcUser;
using Computer.DAL.Entities;
using Homework.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Computer.Business.Concrete
{
    public class PcUserService : IPcUserService
    {
        public readonly ComputerDbContext _computerDbContext;
        public PcUserService(ComputerDbContext computerDbContext)
        {
            _computerDbContext = computerDbContext;
        }
        public async Task<List<GetListPcUserDto>> GetPcUserList()
        {
            return await _computerDbContext.PcUsers.Include(p => p.UserFK).Include(p => p.UserFK).Where(p => !p.IsDeleted).Select(p => new GetListPcUserDto
            {
                Id = p.Id,
                PcName = p.PcFK.Name,
                PcPrice = p.PcFK.Price,
                UserName = p.UserFK.Name,
                UserSurname = p.UserFK.Surname
            }).ToListAsync();
        }
        public async Task<GetPcUserDto> GetPcUserById(int id)
        {
            return await _computerDbContext.PcUsers.Include(p => p.PcFK).Include(p => p.UserFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetPcUserDto
            {
                PcName = p.PcFK.Name,
                PcPrice = p.PcFK.Price,
                UserName = p.UserFK.Name,
                UserSurname = p.UserFK.Surname
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddPcUser(AddPcUserDto addPcUserDto)
        {
            var newPcUser = new PcUser
            {
                PcId = addPcUserDto.PcId,
                UserId = addPcUserDto.UserId
            };
            await _computerDbContext.PcUsers.AddAsync(newPcUser);
            return await _computerDbContext.SaveChangesAsync();

        }
        public async Task<int> UpdatePcUser(int id, UpdatePcUserDto updatePcUserDto)
        {
            var currentPcUser = await _computerDbContext.PcUsers.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentPcUser!=null)
            {
                currentPcUser.PcId = updatePcUserDto.PcId;
                currentPcUser.UserId = updatePcUserDto.UserId;
                currentPcUser.MDate = DateTime.Now;
                _computerDbContext.PcUsers.Update(currentPcUser);
                return await _computerDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeletePcUser(int id)
        {
            var pcUser = await _computerDbContext.PcUsers.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (pcUser!=null)
            {
                pcUser.IsDeleted = true;
                return await _computerDbContext.SaveChangesAsync();
            }
            return -1;
        }
    }
}
