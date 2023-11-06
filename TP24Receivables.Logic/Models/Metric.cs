using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Logic.Models
{
    public class Metric
    {
        public int Count { get; set; }
        public double CountRate { get; set; }
        public double Value { get; set; }
        public double ValueRate { get; set; }

        public Metric()
        {
        }
    }
}
