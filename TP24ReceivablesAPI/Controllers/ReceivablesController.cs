using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP24Receivables.Data.Models;
using TP24Receivables.Logic;
using TP24Receivables.Logic.Models;

namespace TP24Receivables.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceivablesController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private readonly StatisticsConfig StatisticsConfig;

        public ReceivablesController(IConfiguration configuration, ILogger logger)
        {
            this.Configuration = configuration;
            this.Logger = logger;

            this.Configuration.Bind(StatisticsConfig);
            ;
        }

        [HttpPost]
        public IActionResult Statistics(List<ReceivablesPayLoad> payload)
        {
            var receivables = payload.Select(inputPayload => new Receivable(inputPayload)).ToList();

            var logic = new ReceivablesLogic(receivables, StatisticsConfig);

            var statistics = logic.GetStatistics();

            return Ok(statistics);

            //// Group receivables by debtor
            //var groupedByDebtor = payload.GroupBy(r => r.DebtorName);

            //// Calculate statistics for each debtor
            //var debtorStatistics = groupedByDebtor.Select(group =>
            //{
            //    var debtorName = group.Key;
            //    var receivablesReceived = group.Count();
            //    var openReceivablesValue = group.Where(r => (!r.Cancelled ?? false) && string.IsNullOrEmpty(r.ClosedDate))
            //        .Sum(r => r.OpeningValue);
            //    var closedReceivablesValue = group.Where(r => (!r.Cancelled ?? false) && !string.IsNullOrEmpty(r.ClosedDate))
            //        .Sum(r => r.OpeningValue);

            //    return new
            //    {
            //        DebtorName = debtorName,
            //        ReceivablesReceived = receivablesReceived,
            //        OpenReceivablesValue = openReceivablesValue,
            //        ClosedReceivablesValue = closedReceivablesValue
            //    };
            //});

            //return Ok(debtorStatistics);
        }
    }
}
