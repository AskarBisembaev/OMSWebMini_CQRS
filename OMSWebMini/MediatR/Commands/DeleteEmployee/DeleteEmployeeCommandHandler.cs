using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMSWebMini.Data;
using OMSWebMini.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OMSWebMini.MediatR.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly NorthwindContext _context;
        private readonly IMediator _mediator;

        public DeleteEmployeeCommandHandler(NorthwindContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.id);
            if (employee == null)
                throw new KeyNotFoundException(nameof(Employee));

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
