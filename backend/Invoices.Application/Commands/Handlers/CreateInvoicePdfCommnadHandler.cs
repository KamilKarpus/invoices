using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Infrastructure;
using Invoices.Application.Configuration.Processing;
using Invoices.Application.ReadModels;
using Invoices.Application.ReadModels.Product;
using Invoices.Application.Utility;
using MediatR;

namespace Invoices.Application.Commands.Handlers
{
    public class CreateInvoicePdfCommnadHandler : ICommandHandler<CreateInvoicePDFCommand>
    {
        private readonly ISqlConnectionFactory _factory;
        public CreateInvoicePdfCommnadHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<MediatR.Unit> Handle(CreateInvoicePDFCommand request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var invoice = await GetInvoice(request.Id, conn);
            var products = await GetProducts(request.Id, conn);
            var sb = new InvoiceTemplateGenerator();
            IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(@"D:\invoices\{0}.pdf", request.Id);
            Renderer.RenderHtmlAsPdf(sb.GetHTMLInvoice(invoice, products)).SaveAs(stringBuilder.ToString());
            await AddFileInfo(request.Id, conn);
            return await MediatR.Unit.Task;
        }

        private async Task<IEnumerable<ProductDTO>> GetProducts(Guid id, IDbConnection conn)
        {
          return await conn.QueryAsync<ProductDTO>(
          "SELECT i.id, i.nettopay, i.grosstopay, p.name, p.netperunit, p.grossperunit, p.quantity, p.id as productId" +
          " FROM public.invoice i " +
          " inner join product p on i.id = p.invoiceid" +
          " where i.id= @Id", new { Id = id});
        }

        private async Task<InvoiceViewWithCustomer> GetInvoice(Guid id, IDbConnection conn)
        {
           return await conn.QuerySingleAsync<InvoiceViewWithCustomer>("SELECT i.id, number, numberyear," +
           "creationdate, saledate, paymentdeadline, " +
           "nettopay, grosstopay, " +
           "currency, vatrate, c.name as customername, " +
           "c.surname as customersurname, o.name as organizationname, o.nip as orgnip," +
           "o.street as OrganizationStreet, " +
           "r.companyname, r.bankaccountnumber, r.bankname, " +
           " r.nip as CompanyNip, r.street as CompanyAdress " +
           " FROM public.invoice i " +
           " JOIN registercustomer c on i.customerid = c.id " +
           " JOIN registercustomerorganization o on c.id_organization = o.id " +
           " JOIN registerseller r on i.sellerid = r.id" +
           " where i.id = @Id", new { Id = id });
        }
        private async Task AddFileInfo(Guid id, IDbConnection conn)
        {
           await  conn.ExecuteAsync("INSERT INTO public.files(id, occurancedate, typa, filename, invoiceid, path) " +
                $"VALUES('{Guid.NewGuid()}', '{DateTime.Now}', 'application/pdf', '{id}.pdf', '{id}', @path); ", new { path = @"D:\invoices\" });
        }
    }
}
