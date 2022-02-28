using System.Windows;
using Parcial.Entidades;
using Parcial.BLL;
using System;

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

            if (string.IsNullOrWhiteSpace(Producto.Descripcion))
            {
                esValido = false;
                DescripcionTextBox.Focus();
                MessageBox.Show("Debe digitar una Descripcion!!", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(Producto.Costo.ToString()))
            {
                esValido = false;
                CostoTextBox.Focus();
                MessageBox.Show("Debe digitar un Costo!!", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            if(Producto.Existencia  <=0 )
            {
                esValido = false;
                ExistenciaTextBox.Focus();
                MessageBox.Show("Debe digitar Existencia!!", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (Producto.Costo <= 0)
            {
                esValido = false;
                CostoTextBox.Focus();
                MessageBox.Show("Debe digitar un Costo!!", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            else if (string.IsNullOrWhiteSpace(Producto.Existencia.ToString()))
            {
                esValido = false;
                ExistenciaTextBox.Focus();
                MessageBox.Show("Debe digitar  Existencia!!", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (ProductosBLL.Existe(Producto.ProductoId))
            {
                MessageBox.Show("El Producto ya Existe!!", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);
                esValido = false;
            }
            return esValido;
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = ProductosBLL.Buscar(this.Producto.ProductoId);
            if (encontrado != null)
            {
                this.Producto = encontrado;
                Cargar();
                CalcularValorInventario();
                
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

        }
        private int CalcularValorInventario()
        {

            int InventarioValor = Convert.ToInt32(CostoTextBox.Text) * Convert.ToInt32(ExistenciaTextBox.Text);
            ValorInventarioTextBox.Text = InventarioValor.ToString();

            return InventarioValor;


        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            CalcularValorInventario();

            if (!Validar())
                return;

            if (ProductosBLL.Existe(DescripcionTextBox.Text))
            {
                MessageBox.Show("Ya existe este producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ProductosBLL.Guardar(Producto))
            {
                Limpiar();
                CalcularValorInventario();
                MessageBox.Show("Producto Guardado con exito!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            else
                MessageBox.Show("No se pudo Guardar el producto!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);


        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            if (ProductosBLL.Eliminar(Producto.ProductoId))
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