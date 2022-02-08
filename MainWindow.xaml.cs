using System.Windows;
using Parcial.Entidades;
using Parcial.BLL;
using Parcial.DAL;
using System;
using Parcial.UI.Consultas;
using Parcial.UI.Registro;
//PUSH

namespace Parcial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrarMenuItem_Click(object sander, RoutedEventArgs e)
        {
            var rProductos = new rProductos();
            rProductos.Show();
        }
        private void ConsultarMenuItem_Click(object sander, RoutedEventArgs e)
        {
            var cProductos = new  cProductos();
            cProductos.Show();
        }
    }
}
