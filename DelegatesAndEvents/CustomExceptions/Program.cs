using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class OrderProcessingExcpetion : Exception, ISerializable
    {
        public OrderProcessingExcpetion(int orderID)
        {
            OrderId = orderID;
            this.HelpLink = "giyf";
        }
        public OrderProcessingExcpetion(int orderID, string message) : base(message)
        {
            OrderId = orderID;
            this.HelpLink = "giyf";
        }
        public OrderProcessingExcpetion(int orderID, string message, Exception ex) : base(message, ex)
        {
            OrderId = orderID;
            this.HelpLink = "giyf";
        }

        public int OrderId { get; private set; }
    }
}
