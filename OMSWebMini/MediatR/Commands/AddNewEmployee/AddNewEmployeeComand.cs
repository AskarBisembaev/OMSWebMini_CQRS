using MediatR;
using System;

namespace OMSWebMini.MediatR.Commands.AddNewEmployee
{
    public class AddNewEmployeeComand : IRequest<int>
    {
        public int id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
