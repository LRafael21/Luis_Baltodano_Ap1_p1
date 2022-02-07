using System;
using System.ComponentModel.DataAnnotations;

namespace Parcial.Entidades
{
   
    public class Productos
    {
        //ProductoId, Descripcion, Existencia, Costo y ValorInventario
        [Key]
        public int ProductoId { get; set; }

        public string Descripcion { get; set; }
        public int  Existencia { get; set; }
        public int Costo { get; set; }
        public int ValorInventario { get; set; }

    }
}
