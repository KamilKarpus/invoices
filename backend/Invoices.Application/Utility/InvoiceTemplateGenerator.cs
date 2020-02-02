using Invoices.Application.ReadModels;
using Invoices.Application.ReadModels.Product;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Application.Utility
{
    public class InvoiceTemplateGenerator
    {
        public string GetHTMLInvoice(InvoiceViewWithCustomer invoice, IEnumerable<ProductDTO> products)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(@"<!DOCTYPE html>
                  <!DOCTYPE html>
                    <html lang='pl'>
                        <head>
                            <meta charset='utf-8'>
                            <title>faktura</title>
                        </head>
                        <style>
                            .flex-container {
                                display: flex;
                                flex-direction: column;
                            }
                            .header{
                                text-align: center;
                                width: 100%;
                            }
                            .row-left{
                                float:left;
                                width: 50%;  
                            }
                            .row-right{
                                float:right;
                                width: 50%;  
                            }
                        </style>
                        <body>

                            <div>
                           ");
            stringBuilder.AppendFormat(@"<div class='header'>
                                    <p><b><p><b>Faktura nr {0}/{1} </b></p></b></p>
                                </div>",invoice.Number, invoice.Numberyear);
            stringBuilder.AppendFormat(@"<div class='row-left'>
                         Sprzedawca: <b>{0}</b> <br>
                         Adres: <b>{1}</b><br>
                         NIP: <b>{2}</b>
                        <br>
                        <br>
                    </div>", invoice.Companyname, invoice.CompanyAdress, invoice.CompanyNip);
            stringBuilder.AppendFormat(@"<div class='row-right'>
                                        Nabywca: <b>{0}</b><br>
                                        Organizacja: <b>{1}</b><br>
                                        Adres: <b>{2}</b><br>
                                        NIP: {3}
                                    </div>", $"{invoice.Customername} {invoice.Customersurname}",
                                    invoice.Organizationname,invoice.OrganizationStreet, invoice.Orgnip);
            stringBuilder.AppendFormat(@"<div>
                                        Sposob płatności: <b>Przelew</b>
                                        Termin płatności: <b>2013-01-24</b><br>
                                        Bank: <b>{0}</b>
                                        Numer konta: <b>{1}</b>
                                    </div>", invoice.Bankname, invoice.Bankaccountnumber);
            
            stringBuilder.Append(@"
                            <div>
                            <br>
                            <table border = '1' >
                                <tr style= 'background-color: #bababa;' >
                                    <th> Lp.</h>
                                    <th> Nazwa </th>
                                    <th> Ilość </th>
                                    <th> Cena netto</th>
                                    <th>Wartość netto</th>
                                    <th>Stawka VAT</th>
                                    <th>Kwota VAT</th>
                                    <th>Wartość brutto</th>
                                </tr>

                                ");
            int pos = 1;
            decimal toPay = 0;
            foreach (var product in products)
            {

                stringBuilder.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>                
                                </tr>", pos,product.Name,
                                product.Quantity,
                                product.Netperunit,
                                (product.Netperunit * product.Quantity),
                                "23%",
                                ((product.Grossperunit * product.Quantity)- (product.Netperunit * product.Quantity)),
                                (product.Grossperunit * product.Quantity));
                pos++;
                toPay += (product.Netperunit * product.Quantity);
            }
            stringBuilder.AppendFormat(@"
                            </table>
        
                            </div>
                                    <p>Razem do zapłaty: <b>{0}</b> PLN</p>
                          ", toPay);
            stringBuilder.Append(@"<div class='row-left'>
                                    <p>Podpis odbiorcy</p>
                                    </div>

                                    <div class='row-right'>
                                        <p>Podpis wystawiającego</p>
                                    </div>
                                </div>
            
                           </div>
                        </body>
                    </html>");
            return stringBuilder.ToString();
        }
    }
}
