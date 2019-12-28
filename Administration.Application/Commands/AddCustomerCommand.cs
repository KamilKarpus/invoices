using Administration.Application.Configuration.Processing;
using System;


namespace Administration.Application.Commands
{
    public class AddCustomerCommand : ICommand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Guid OrganizationId { get; private set; }

        public AddCustomerCommand(Guid id, string name, string surname, Guid organizationId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            OrganizationId = organizationId;
        }

    }
}
