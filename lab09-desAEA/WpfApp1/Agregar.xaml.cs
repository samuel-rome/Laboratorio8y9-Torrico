using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Servicio;
using Datos;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Agregar.xaml
    /// </summary>
    public partial class Agregar : Window
    {

        BInvoice BInvoice = new BInvoice();
        BCustomer BCustomer = new BCustomer();
        public Agregar()
        {
            InitializeComponent();
            
            cmbCustomers.ItemsSource = BCustomer.Get();
        }

       

        private void btnAdd(object sender, RoutedEventArgs e)
        {

            int selectedCustomerId = (int)cmbCustomers.SelectedValue;

            Invoice invoice = new Invoice()
            {
                Customer_id = selectedCustomerId,
                Date = DateTime.Parse(txtDate.Text),
                Total = decimal.Parse(txtTotal.Text),
                Active = true,
            };

            var result = BInvoice.InsertInvoice(invoice);

            if (result)
            {
                MessageBox.Show("Correcto");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
