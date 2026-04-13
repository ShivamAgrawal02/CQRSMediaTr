using CQRSMediaTr.Data;
using CQRSMediaTr.Features.Employees.Query;
using CQRSMediaTr.Model.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CQRSMediaTr.Features.Employees.Handler
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private readonly CQRSMediaTrDbContext _context;
        public GetAllEmployeesQueryHandler(CQRSMediaTrDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.ToListAsync(cancellationToken);
            return employees;            
        }
    }
}
