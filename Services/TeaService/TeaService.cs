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

        public async Task<ServiceResponse<GetTeaDto>> DeleteTea(int teaId) {
            try {
                var tea = await _context.Teas.FindAsync(teaId);
                if (tea != null) {
                    _context.Teas.Remove(tea);
                    await _context.SaveChangesAsync();
                };
                return new ServiceResponse<GetTeaDto>(Data: _mapper.Map<GetTeaDto>(tea));
            } catch (System.Exception) {
                return new ServiceResponse<GetTeaDto>(Message: ServiceResponseEnum.Error);
            }
        }

        public async Task<ServiceResponse<GetTeaDto>> UpdateTea(UpdateTeaDto updatedTea) {
            try {
                var tea = await _context.Teas.FirstOrDefaultAsync<Tea>(c => c.Id == updatedTea.Id);
                if (tea != null) {
                    tea.Name = updatedTea.Name;
                    tea.Description = updatedTea.Description;
                    tea.DrinkType = updatedTea.DrinkType;
                    tea.Price = updatedTea.Price;
                    await _context.SaveChangesAsync();
                };
                return new ServiceResponse<GetTeaDto>(Data: _mapper.Map<GetTeaDto>(tea));
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

        public async Task<ServiceResponse<List<GetTeaDto>>> GetAllTea() {
            try {
                var teas = await _context.Teas.Include(x => x.Bartenders).ToListAsync();
                return new ServiceResponse<List<GetTeaDto>>(Data: teas.Select(c => _mapper.Map<GetTeaDto>(c)).ToList());
            } catch (System.Exception) {
                return new ServiceResponse<List<GetTeaDto>>(Message: ServiceResponseEnum.Error);
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