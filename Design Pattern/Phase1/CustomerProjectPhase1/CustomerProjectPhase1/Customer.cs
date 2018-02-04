using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCustomer;
namespace MiddleLayer
{

    public class CustomerBase : ICustomer
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }

        public virtual void Validate()
        {

        }
    }
    public class Customer : CustomerBase
    {
        public override void Validate()
        {

            if (string.IsNullOrEmpty(CustomerName))
                throw new Exception("Customer Name required");

            if (string.IsNullOrEmpty(PhoneNumber))
                throw new Exception("Phone Number required");


            if (BillAmount == 0)
                throw new Exception("Bill Amount required");

            if (BillDate > DateTime.Now)
                throw new Exception("Bill Date cannot be greater than today's date");

            if (string.IsNullOrEmpty(Address))
                throw new Exception("Address required");

        }
    }

    public class Lead : CustomerBase
    {
        public override void Validate()
        {
            if (string.IsNullOrEmpty(CustomerName))
                throw new Exception("Customer Name required");

            if (string.IsNullOrEmpty(PhoneNumber))
                throw new Exception("Phone Number required");
        }
    }
}
