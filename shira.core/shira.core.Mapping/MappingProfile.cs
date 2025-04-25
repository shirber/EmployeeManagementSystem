using AutoMapper;
using shira.core.DTOs;
using shira.core.Entities;
using shira.core.shira.core.DTOs;

namespace shira.core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<WorkHour, WorkHourDTO>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        }
    }
}
