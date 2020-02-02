using System;

namespace Invoices.Application.ReadModels
{
    public class CustomFileInfo
    {
       public Guid Id { get; set; }
       public DateTime Occurancedate {get; set;}
       public string Typa {get; set;}
       public string Filename {get; set;}
       public string Path {get; set;}


    }
}
