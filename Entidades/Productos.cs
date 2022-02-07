using System.ComponentModel.DataAnnotations;

namespace Parcial.Entidades
{

    public class Productos
    {
        //ProductoId, Descripcion, Existencia, Costo y ValorInventario
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public bool Existencia { get; set; }
        public int Costo { get; set; }
        public int ValorInventario { get; set; }

    }
}
