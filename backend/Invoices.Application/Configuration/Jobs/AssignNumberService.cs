

using Dapper;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Invoices.Application.Configuration.Jobs
{
    public class AssignNumberService
    {
        private readonly ISqlConnectionFactory _factory;
        public AssignNumberService(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<Job>> FetchPendingJobs(IDbConnection conn )
        {
            return await conn.QueryAsync<Job>("SELECT id, occurrencedate, type, invoiceid "
                + "FROM public.jobs;");
        }
        public async Task TryExecuteJobs()
        {
            var conn = _factory.GetConnection();
            var jobs = await FetchPendingJobs(conn);
            foreach(var job in jobs)
            {
                var lastnumber = await conn.QueryFirstAsync<InvoiceNumber>("SELECT number, numberyear "
                  + "FROM public.invoice"
                  + " Order by number"
                  + " Limit 1;");

                await conn.ExecuteAsync("UPDATE public.invoice set number = @Number, numberyear = @Year "
                   + "where Id = @Id", new { Number = (lastnumber.Number + 1), Year = DateTime.Now.Year, Id = job.InvoiceId });

                await conn.ExecuteAsync("DELETE FROM public.jobs WHERE Id = @Id", new { Id = job.Id });
            }
        }
    }

    public class Job
    {
        public Guid Id { get; set; }
        public DateTime OccuranceDate { get; set; }
        public string Type { get; set; }
        public Guid InvoiceId { get; set; }
    }
}
