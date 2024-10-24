using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands
{


    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            // الحصول على توزيع الإجازة بناءً على المعرف المرسل
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);

            // التحقق إذا كان توزيع الإجازة موجودًا
            if (leaveAllocation == null)
            {
                throw new NotFoundException(nameof(LeaveAllocationn), request.Id);
            }

            // حذف توزيع الإجازة
            await _leaveAllocationRepository.Delete(leaveAllocation);

            // إرجاع القيمة بعد نجاح العملية
            return Unit.Value;
        }
    }


    //public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    //{
    //    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    //    private readonly IMapper _mapper;

    //    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    //    {
    //        _leaveAllocationRepository = leaveAllocationRepository;
    //        _mapper = mapper;
    //    }
    //    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    //    {
    //        var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);
    //        if (leaveAllocation == null)
    //        {
    //            throw new NotFoundException(nameof(LeaveAllocationn) , request.Id);
    //        }
    //        await _leaveAllocationRepository.Delete(leaveAllocation);
    //        return Unit.Value;
    //    }
    //}
}
