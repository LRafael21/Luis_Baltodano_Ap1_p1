using System;
using System.ComponentModel.DataAnnotations;

//NoErrorPorAhora

namespace Parcial.Entidades
{
   
    public class Productos
    {
        //ProductoId, Descripcion, Existencia, Costo y ValorInventario
        [Key]
        public int ProductoId { get; set; }

        public string Descripcion { get; set; }
        public decimal  Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal ValorInventario { get; set; }

    }
}
