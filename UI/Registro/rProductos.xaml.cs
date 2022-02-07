using System.Windows;
using Parcial.Entidades;
using Parcial.BLL;

namespace Luis_Baltodano_Ap1_p1.UI.Registros
{


    public partial class rProductos : Window
    {

        private Productos Productos = new Productos();
        public rProductos()
        {
            InitializeComponent();

            this.DataContext = Productos;


        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.Productos;

        }

        private void Limpiar()
        {
            this.Productos = new Productos();
            this.DataContext = Productos;

        }

        private bool Validar()
        {
            ////ProductoId, Descripcion, Existencia, Costo y ValorInventario
            bool esValido = true;
            if(string.IsNullOrWhiteSpace(Productos.Descripcion))
            {
                esValido = false

            }


            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {


        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {


        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}