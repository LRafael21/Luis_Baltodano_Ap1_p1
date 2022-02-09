using System.Windows;
using Parcial.Entidades;
using Parcial.BLL;

//PUSH

namespace Parcial.UI.Registro
{


    public partial class rProductos : Window
    {

        private Productos Producto = new Productos();
        public rProductos()
        {
            InitializeComponent();

            this.DataContext = Producto;


        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.Producto;

        }

        private void Limpiar()
        {
            this.Producto = new Productos();
            this.DataContext = Producto;

        }

        private bool Validar()
        {
            ////ProductoId, Descripcion, Existencia, Costo y ValorInventario
            bool esValido = true;

            if(string.IsNullOrWhiteSpace(Producto.Descripcion))
            {
                esValido = false;
                DescripcionTextBox.Focus();
                MessageBox.Show("Debe digitar una Descripcion!!", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(Producto.Costo.ToString()))
            {
                esValido = false;
                CostoTextBox.Focus();
                MessageBox.Show("Debe digitar un  Costo!!", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = ProductosBLL.Buscar(this.Producto.ProductoId);
            if(encontrado != null)
            {
                this.Producto = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro el producto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            MessageBox.Show("No se encontro el producto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
           

            if(!Validar())
                return;
            if(ProductosBLL.Guardar(Producto))
                MessageBox.Show("Producto Guardado con exito!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo Guardar el producto!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProductosBLL.Eliminar(Producto.ProductoId))
            {
                Limpiar();
                MessageBox.Show(" Producto Eliminado con exito!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(" No se pudo eliminar el producto!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);
                }

        }
    }
}