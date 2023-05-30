using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIXAnalyzer
{
    class Order
    {
        public List<Dictionary<string, Order>> History { get; set; }
        public string OrderId { get; set; }
        public char OrdType { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string Symbol { get; set; }
        public char Side { get; set; }
        public string TimeInForce { get; set; } 
        public int LeavesQty { get; set; }
        public int FillQty { get; set; }
        public char OrdStatus { get; set; }
        public string TrdMatchID { get; set; }

    }

    internal class Account
    {
        public string AccountID;
        public Dictionary<string,Order> Orders;
    }
}
