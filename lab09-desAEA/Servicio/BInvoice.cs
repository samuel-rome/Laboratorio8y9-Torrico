using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class BInvoice
    {

        DInvoice dInvoice = new DInvoice(configuration);

        public List<Invoice> Get() {
            var invoices = dInvoice.Get();
            return invoices;
        }

        public List<Invoice> GetByDate(DateTime date)
        {
            var invoices = dInvoice.Get();
            var result = invoices.Where(x=>x.Date == date).ToList();
            return result;
        }

        public bool InsertInvoice(Invoice request)
        {
            var result = dInvoice.Insert(request);
            return result;
        }

        public bool DeleteInvoice(int id)
        {
            try
            {

                var result = dInvoice.Delete(id);

                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
