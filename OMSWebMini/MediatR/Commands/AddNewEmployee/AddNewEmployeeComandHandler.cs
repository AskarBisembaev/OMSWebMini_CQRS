using MediatR;
using OMSWebMini.Data;
using OMSWebMini.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OMSWebMini.MediatR.Commands.AddNewEmployee
{
    public class AddNewEmployeeComandHandler : IRequestHandler<AddNewEmployeeComand, int>
    {
        private readonly NorthwindContext _context;
        private readonly IMediator _mediator;

        public AddNewEmployeeComandHandler(NorthwindContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<int> Handle(AddNewEmployeeComand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                EmployeeId = request.id,
                LastName = request.LastName,
                FirstName = request.FirstName,
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return 1;
        }
    }
}
