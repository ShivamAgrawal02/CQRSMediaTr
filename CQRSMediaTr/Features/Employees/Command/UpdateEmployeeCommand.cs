using CQRSMediaTr.Model.DTO;
using MediatR;

namespace CQRSMediaTr.Features.Employees.Command
{
    public record UpdateEmployeeCommand( int Id, EmployeeUpdateDTO Employee):IRequest<bool>
    {
    }
}
