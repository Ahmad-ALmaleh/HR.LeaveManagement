using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocatoin;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequestt, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequestt, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocationn, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}
