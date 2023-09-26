using AutoMapper;
using teahouse.Dtos.Tea;
using teahouse.Models;

namespace teahouse.Services.TeaService {
    public class TeaService : ITeaService {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TeaService(IMapper mapper, DataContext context) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetTeaDto>> AddTea(AddTeaDto tea) {
            try {
                Tea newTea = _mapper.Map<Tea>(tea);
                await _context.Teas.AddAsync(newTea);
                _context.SaveChanges();
                return new ServiceResponse<GetTeaDto>(Data: _mapper.Map<GetTeaDto>(newTea));
            } catch (System.Exception) {
                return new ServiceResponse<GetTeaDto>(Message: ServiceResponseEnum.Error);
            }
        }

        public async Task<List<GetTeaDto>> GetAllTeas() {
            try {
                var teas = await _context.Teas.Include(x => x.Bartenders).ToListAsync();
                return teas.Select(c => _mapper.Map<GetTeaDto>(c)).ToList();
            } catch (System.Exception) {
                return new();
            }
        }

        public async Task<ServiceResponse<GetTeaDto>> GetTea(int id) {
            try {
                var tea = await _context.Teas.FirstOrDefaultAsync(t => t.Id == id);
                return new ServiceResponse<GetTeaDto>(Data: _mapper.Map<GetTeaDto>(tea));
            } catch (System.Exception) {
                return new ServiceResponse<GetTeaDto>(Message: ServiceResponseEnum.Error);
            }
        }
    }
}