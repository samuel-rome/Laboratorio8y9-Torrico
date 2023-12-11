using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class BCustomer
    {
        DCustomer dCustomer = new DCustomer();


        public List<Customer> Get()
        {
            var customer = dCustomer.GetCustomers();
            return customer;
        }
    }
}
