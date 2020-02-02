using System;

namespace Invoices.Application.ReadModels
{
    public class InvoiceViewWithCustomer
    {   
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Numberyear { get; set; }
        public DateTime Creationdate  { get; set; }
        public DateTime Saledate { get; set; }
        public DateTime Paymentdeadline { get; set; } 
        public decimal Nettopay  { get; set; }
        public decimal Grosstopay { get; set; }
        public string Currency  { get; set; }
        public int Vatrate { get; set; }
        public string Customername  { get; set; }
        public string Customersurname { get; set; }
        public string Organizationname  { get; set; }
        public int Orgnip { get; set; }
        public string Companyname { get; set; }
        public string Bankaccountnumber  { get; set; }
        public string Bankname { get; set; }
        public string CompanyAdress { get; set; }
        public int CompanyNip { get; set; }
        public string OrganizationStreet { get; set; }
    }
}
