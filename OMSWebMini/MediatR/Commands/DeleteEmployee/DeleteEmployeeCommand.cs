using MediatR;
using OMSWebMini.Models;
using System.Collections.Generic;

namespace OMSWebMini.MediatR.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int id { get; set; }
    }
}
