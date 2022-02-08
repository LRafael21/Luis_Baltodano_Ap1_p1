using System.Windows;
using Parcial.Entidades;
using Parcial.BLL;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

//PUSH

namespace Parcial.UI.Consultas
{
    public partial class cProductos : Window
{

    public cProductos()
    {
        InitializeComponent();
    }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();

            if (string.IsNullOrWhiteSpace(CriterioTextBoxx.Text))
            {
             listado = ProductosBLL.GetList(e => true);
            }
            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProductosBLL.GetList(e => e.Descripcion.Contains(CriterioTextBoxx.Text));
                        break;

                }

                ProductosDataGrid.ItemsSource = null;
                ProductosDataGrid.ItemsSource = listado;

            }
        }

       


   }
}