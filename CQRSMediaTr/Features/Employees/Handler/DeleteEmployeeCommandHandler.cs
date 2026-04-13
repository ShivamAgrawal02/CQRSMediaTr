using CQRSMediaTr.Data;
using CQRSMediaTr.Features.Employees.Command;
using CQRSMediaTr.Model.Domain;
using MediatR;

namespace CQRSMediaTr.Features.Employees.Handler
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand,bool>
    {
        private readonly CQRSMediaTrDbContext _context;
        public DeleteEmployeeCommandHandler(CQRSMediaTrDbContext context)
        {  
           _context = context; 
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee==null)
            {
                return false;

            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
