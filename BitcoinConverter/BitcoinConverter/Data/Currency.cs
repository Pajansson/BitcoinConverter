using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinConverter.Data
{
    public class Currency
    {
        public string Code { get; set; }
        public string Rate { get; set; }
        public string Description { get; set; }
        public double RateFloat { get; set; }
    }
}
