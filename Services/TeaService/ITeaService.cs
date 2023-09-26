using teahouse.Dtos.Tea;
using teahouse.Models;

namespace teahouse.Services.TeaService {
    public interface ITeaService {
        Task<List<GetTeaDto>> GetAllTeas();
        Task<ServiceResponse<GetTeaDto>> GetTea(int id);
        Task<ServiceResponse<GetTeaDto>> AddTea(AddTeaDto tea);
        Task<ServiceResponse<GetTeaDto>> DeleteTea(int teaId);
        Task<ServiceResponse<GetTeaDto>> UpdateTea(UpdateTeaDto tea);
    }
}