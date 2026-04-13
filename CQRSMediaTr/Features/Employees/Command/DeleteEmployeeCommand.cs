using CQRSMediaTr.Model.Domain;
using MediatR;

namespace CQRSMediaTr.Features.Employees.Command
{
    public record DeleteEmployeeCommand(int Id):IRequest<bool>
    {
    }
}
