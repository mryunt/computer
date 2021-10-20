using Computer.DAL.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Computer.Business.Abstract
{
    public interface IUserService
    {
        public Task<List<GetListUserDto>> GetUserList();
        public Task<GetUserDto> GetUserById(int id);
        public Task<int> AddUser(AddUserDto addUserDto);
        public Task<int> UpdateUser(int id, UpdateUserDto updateUserDto);
        public Task<int> DeleteUser(int id);
    }
}
