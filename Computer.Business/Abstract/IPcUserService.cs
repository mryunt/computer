using Computer.DAL.Dtos.PcUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Business.Abstract
{
    public interface IPcUserService
    {
        public Task<List<GetListPcUserDto>> GetPcUserList();
        public Task<GetPcUserDto> GetPcUserById(int id);
        public Task<int> AddPcUser(AddPcUserDto addPcUserDto);
        public Task<int> UpdatePcUser(int id, UpdatePcUserDto updatePcUserDto);
        public Task<int> DeletePcUser(int id);
    }
}
