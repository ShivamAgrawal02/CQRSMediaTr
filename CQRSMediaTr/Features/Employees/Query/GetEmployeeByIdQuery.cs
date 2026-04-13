using CQRSMediaTr.Model.Domain;
using MediatR;

namespace CQRSMediaTr.Features.Employees.Query
{
    public record GetEmployeeByIdQuery(int Id):IRequest<Employee>
    {
    }
}
