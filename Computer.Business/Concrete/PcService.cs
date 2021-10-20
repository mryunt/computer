using Computer.Business.Abstract;
using Computer.DAL.Dtos.Pc;
using Computer.DAL.Entities;
using Homework.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Computer.Business.Concrete
{
    public class PcService : IPcService
    {
        private readonly ComputerDbContext _computerDbContext;
        public PcService(ComputerDbContext computerDbContext)
        {
            _computerDbContext = computerDbContext;
        }
        public async Task<List<GetListPcDto>> GetPcList()
        {
            return await _computerDbContext.Pcs.Where(p => !p.IsDeleted).Select(p => new GetListPcDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToListAsync();
        }
        public async Task<GetPcDto> GetPcById(int id)
        {
            return await _computerDbContext.Pcs.Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetPcDto
            {
                Name = p.Name,
                Price = p.Price
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddPc(AddPcDto addPcDto)
        {
            var newPc = new Pc
            {
                Name = addPcDto.Name,
                Price = addPcDto.Price
            };
            await _computerDbContext.Pcs.AddAsync(newPc);
            return await _computerDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdatePc(int id, UpdatePcDto updatePcDto)
        {
            var currentPc = await _computerDbContext.Pcs.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentPc!=null)
            {
                currentPc.Name = updatePcDto.Name;
                currentPc.Price = updatePcDto.Price;
                currentPc.MDate = DateTime.Now;
                _computerDbContext.Pcs.Update(currentPc);
                return await _computerDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeletePc(int id)
        {
            var pc = await _computerDbContext.Pcs.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (pc!=null)
            {
                pc.IsDeleted = true;
                return await _computerDbContext.SaveChangesAsync();
            }
            return -1;
        }
    }
}
