using CQRSMediaTr.Model.Domain;
using MediatR;

namespace CQRSMediaTr.Features.Employees.Query
{
    public record GetAllEmployeesQuery:IRequest<List<Employee>>{    }
}
