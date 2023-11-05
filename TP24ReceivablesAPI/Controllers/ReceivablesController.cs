using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP24Receivables.Data.Models;
using TP24Receivables.Logic;
using TP24Receivables.Logic.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Filters;

namespace TP24Receivables.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceivablesController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private readonly StatisticsConfig _statisticsConfig;

        public ReceivablesController(IOptions<StatisticsConfig> statisticsConfig)
        {
            _statisticsConfig = statisticsConfig.Value;
            //this.Logger = logger;
            ;
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(Payload), typeof(PayloadExample))]
        public IActionResult Statistics(List<Payload> payload)
        {
            var debtors = PayloadParser.Parse(payload);

            var logic = new ReceivablesLogic(debtors, _statisticsConfig);

            var statistics = logic.GetStatisticsForAllReceivables();

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
