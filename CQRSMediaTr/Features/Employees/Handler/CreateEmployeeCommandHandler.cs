using CQRSMediaTr.Data;
using CQRSMediaTr.Features.Employees.Command;
using CQRSMediaTr.Model.Domain;
using MediatR;

namespace CQRSMediaTr.Features.Employees.Handler
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly CQRSMediaTrDbContext _context;
        public CreateEmployeeCommandHandler(CQRSMediaTrDbContext context)
        {
            _context= context;
        }
        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(request.Employee);
            await _context.SaveChangesAsync();
            return request.Employee;
        }
    }
}
