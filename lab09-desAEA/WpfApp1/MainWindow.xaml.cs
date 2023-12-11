using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Entity;
using Servicio;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BInvoice bInvoice = new BInvoice();
        public MainWindow()
        {
            InitializeComponent();

            ListarDatos();


        }

        public void btnAdd(object sender, RoutedEventArgs e)
        {
            Agregar agregar = new Agregar();
            agregar.Closed += AgregarClosedHandler;
            agregar.Show();

        }

        private void AgregarClosedHandler(object sender, EventArgs e)
        {
            Agregar agregar = (Agregar)sender;

            ListarDatos();

            agregar.Closed -= AgregarClosedHandler;
        }

        public void ListarDatos()
        {
            var data = bInvoice.Get();
            var registrosNoVacios = data.Where(item => item != null); 
            dataGrid.ItemsSource = registrosNoVacios;
        }

        public void btnFilter(object sender, RoutedEventArgs e)
        {
            Filtrar filtrar = new Filtrar();
            filtrar.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            var button = (Button)sender;
            var invoice = (Invoice)button.Tag;

            if (MessageBox.Show("¿Estás seguro de que deseas eliminar este elemento?", "Confirmar eliminación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                bInvoice.DeleteInvoice(invoice.Invoice_id);
                ListarDatos();
            }
        }
    }
}
