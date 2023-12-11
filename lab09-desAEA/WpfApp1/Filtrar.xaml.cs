using Servicio;
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

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Filtrar.xaml
    /// </summary>
    public partial class Filtrar : Window
    {
        public Filtrar()
        {
            InitializeComponent();
        }

        private void btnFilter(object sender, RoutedEventArgs e)
        {

            BInvoice bInvoice = new BInvoice();
            var date = DateTime.Parse(txtFilterDate.Text);
            dataGrid.ItemsSource = bInvoice.GetByDate(date);


        }
    }
}
