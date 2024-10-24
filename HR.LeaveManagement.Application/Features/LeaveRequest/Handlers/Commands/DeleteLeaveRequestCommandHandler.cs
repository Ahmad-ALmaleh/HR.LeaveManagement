using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{


    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            // الحصول على طلب الإجازة بناءً على المعرف المرسل
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            // التحقق إذا كان طلب الإجازة موجودًا
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequestt), request.Id);
            }

            // حذف طلب الإجازة
            await _leaveRequestRepository.Delete(leaveRequest);

            // إرجاع القيمة بعد نجاح العملية
            return Unit.Value;
        }
    }


    //public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    //{
    //    private readonly ILeaveRequestRepository _leaveRequestRepository;
    //    private readonly IMapper _mapper;

    //    public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    //    {
    //        _leaveRequestRepository = leaveRequestRepository;
    //        _mapper = mapper;
    //    }
    //    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    //    {
    //        var leaveRequest = await _leaveRequestRepository.Get(request.Id);
    //        if (leaveRequest == null)
    //        {
    //            throw new NotFoundException(nameof(LeaveRequestt), request.Id);
    //        }
    //        await _leaveRequestRepository.Delete(leaveRequest);
    //        return Unit.Value;
    //    }
    //}
}
