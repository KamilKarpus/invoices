using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.ReadModels.Customer
{
    public class CustomerView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get;  set; }
    }
}
