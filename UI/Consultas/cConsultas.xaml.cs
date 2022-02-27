using System.Windows;
using Parcial.Entidades;
using Parcial.BLL;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

//PUSH

namespace Parcial.UI.Consultas
{
    public partial class cProductos : Window
{
        private Productos Producto = new Productos();

    public cProductos()
    {
        InitializeComponent();
    }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();

            if (CriterioTextBoxx.Text.Trim().Length > 0)
            {

                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:

                        listado = ProductosBLL.GetList(e => e.Descripcion.ToLower().Contains(CriterioTextBoxx.Text.ToLower()));

                        break;

                    case 1:
                        listado = ProductosBLL.GetList(e => e.ProductoId == Convert.ToInt32(CriterioTextBoxx.Text));


                        break;
                }
            }
            else
            {
                listado = ProductosBLL.GetList(e => true);
            }

            ProductosDataGrid.ItemsSource = null;
            ProductosDataGrid.ItemsSource = listado;





        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.Producto;

        }

    }
}