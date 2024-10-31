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
            #region LeaveRequest Mappings
            CreateMap<LeaveRequestt, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequestt, LeaveRequestListDto>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DateCreated))
                .ReverseMap();
            CreateMap<LeaveRequestt, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequestt, UpdateLeaveRequestDto>().ReverseMap();
            #endregion LeaveRequest

            CreateMap<LeaveAllocationn, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocationn, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocationn, UpdateLeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
        }
    }
}
