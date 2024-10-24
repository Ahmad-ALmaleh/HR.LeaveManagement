using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{


    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // الحصول على نوع الإجازة بناءً على المعرف المرسل
            var leaveType = await _leaveTypeRepository.Get(request.Id);

            // التحقق إذا كان نوع الإجازة موجودًا
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            // حذف نوع الإجازة
            await _leaveTypeRepository.Delete(leaveType);

            // إرجاع القيمة بعد نجاح العملية
            return Unit.Value;
        }
    }


    //public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    //{
    //    private readonly ILeaveTypeRepository _leaveTypeRepository;
    //    private readonly IMapper _mapper;

    //    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    //    {
    //        _leaveTypeRepository = leaveTypeRepository;
    //        _mapper = mapper;
    //    }
    //    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    //    {
    //        var leaveType = await _leaveTypeRepository.Get(request.Id);
    //        if (leaveType == null)
    //        {
    //            throw new NotFoundException(nameof(LeaveType) , request.Id);
    //        }
    //        await _leaveTypeRepository.Delete(leaveType);
    //        return Unit.Value;
    //    }
    //}
}
