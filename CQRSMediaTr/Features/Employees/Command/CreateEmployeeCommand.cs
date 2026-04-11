using CQRSMediaTr.Model.Domain;
using MediatR;

namespace CQRSMediaTr.Features.Employees.Command
{
    public record CreateEmployeeCommand(Employee Employee):IRequest<Employee>
    {
    }
}
