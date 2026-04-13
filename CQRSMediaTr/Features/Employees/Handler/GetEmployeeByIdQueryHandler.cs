using CQRSMediaTr.Data;
using CQRSMediaTr.Features.Employees.Query;
using CQRSMediaTr.Model.Domain;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CQRSMediaTr.Features.Employees.Handler
{
   
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly CQRSMediaTrDbContext _context;
        public GetEmployeeByIdQueryHandler(CQRSMediaTrDbContext context)
        {
            _context = context;
        }
        public  async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            return employee;
        }
    }
}
