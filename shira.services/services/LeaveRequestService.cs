using AutoMapper;
using shira.core.Entities;
using shira.core.repositories;
using shira.core.services;
using shira.core.shira.core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shira.services.services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IMapper _mapper;

        public LeaveRequestService(ILeaveRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<LeaveRequestDto>>(entities);
        }

        public async Task<LeaveRequestDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<LeaveRequestDto>(entity);
        }

        public async Task<LeaveRequestDto> AddAsync(LeaveRequestDto dto)
        {
            var entity = _mapper.Map<LeaveRequest>(dto);
            var result = await _repository.AddAsync(entity);
            return _mapper.Map<LeaveRequestDto>(result);
        }

        public async Task<LeaveRequestDto?> UpdateAsync(LeaveRequestDto dto)
        {
            var entity = _mapper.Map<LeaveRequest>(dto);
            var result = await _repository.UpdateAsync(entity);
            return result == null ? null : _mapper.Map<LeaveRequestDto>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
