using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP24Receivables.Data.Models;
using TP24Receivables.Logic;
using TP24Receivables.Logic.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TP24Receivables.Logic.Classes;
using TP24Receivables.Repository;

namespace TP24Receivables.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceivablesController : ControllerBase
    {
        private readonly StatisticsConfig _statisticsConfig;
        private readonly IDebtorRepository _debtorRepository;

        public ReceivablesController(IOptions<StatisticsConfig> statisticsConfig, IDebtorRepository debtorRepository)
        {
            _debtorRepository = debtorRepository;
            _statisticsConfig = statisticsConfig.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Statistics(List<Payload> payload)
        {
            try
            {
                var debtors = PayloadParser.Parse(payload);

                foreach (var debtor in debtors)
                {
                    await _debtorRepository.SaveDebtor(debtor);
                }

                var logic = new ReceivablesLogic(debtors, _statisticsConfig);

                var statistics = logic.GetStatisticsForAllDebtors();

                return Ok(statistics);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex);
                return result;
            }
        }
    }
}
