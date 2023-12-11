using Datos;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: InvoiceController
        public ActionResult Index()
        {
           

            BInvoice bInvoice = new BInvoice();
            List<Invoice> invoiceEntity = bInvoice.Get();

            List<InvoiceModel> invoices = invoiceEntity.Select(x=> new InvoiceModel{
                Invoice_Id = x.Invoice_id,
                Igv = (x.Total*18)/100,
                Total = x.Total
            }).ToList();

            return View(invoices);
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceModel model)
        {
            try
            {
                BInvoice bInvoice = new BInvoice();

                Invoice invoice = new Invoice
                {
                    Customer_id = model.Customer_Id,
                    Total = model.Total,
                    Date = DateTime.Now,    
                };

                bInvoice.InsertInvoice(invoice);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            BInvoice bInvoice = new BInvoice();
            var invoices = bInvoice.Get();
            var result = invoices.FirstOrDefault(x => x.Invoice_id == id);

            return View(result);
        }

        // POST: InvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInvoice( int Invoice_id)
        {
            try
            {
                BInvoice bInvoice = new BInvoice();
                bInvoice.DeleteInvoice(Invoice_id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
