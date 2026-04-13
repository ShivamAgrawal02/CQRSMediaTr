using CQRSMediaTr.Data;
using CQRSMediaTr.Features.Employees.Query;
using CQRSMediaTr.Model.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTr.Features.Employees.Handler
{
    public class GetEmployeesByNameQueryHandler : IRequestHandler<GetEmployeesByNameQuery, List<Employee>>
    {
        private readonly CQRSMediaTrDbContext _context;
        public GetEmployeesByNameQueryHandler(CQRSMediaTrDbContext context)
        {
            _context=context;
        }
        public async Task<List<Employee>> Handle(GetEmployeesByNameQuery request, CancellationToken cancellationToken)
        {
           var employees = await _context.Employees.Where(x=>x.Name==request.Name).ToListAsync(cancellationToken);
           return employees;
        }
    }
}
