using CQRSMediaTr.Model.Domain;
using MediatR;

namespace CQRSMediaTr.Features.Employees.Query
{
    public record GetEmployeesByNameQuery(string Name):IRequest<List<Employee>>
    {
    }
}
