using Computer.DAL.Dtos.Pc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Computer.Business.Abstract
{
    public interface IPcService
    {
        public Task<List<GetListPcDto>> GetPcList();
        public Task<GetPcDto> GetPcById(int id);
        public Task<int> AddPc(AddPcDto addPcDto);
        public Task<int> UpdatePc(int id,UpdatePcDto updatePcDto);
        public Task<int> DeletePc(int id);
    }
}
