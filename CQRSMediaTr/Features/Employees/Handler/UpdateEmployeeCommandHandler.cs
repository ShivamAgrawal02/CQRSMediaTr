using CQRSMediaTr.Data;
using CQRSMediaTr.Features.Employees.Command;
using MediatR;

namespace CQRSMediaTr.Features.Employees.Handler
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly CQRSMediaTrDbContext _context;
        public UpdateEmployeeCommandHandler(CQRSMediaTrDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            if(employee==null)
            {
                return false;
            }
            employee.PanDetails=request.Employee.PanDetails;
            employee.Name=request.Employee.Name;
            employee.Address=request.Employee.Address;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
