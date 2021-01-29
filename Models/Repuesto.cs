using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioTaller.Models
{
    public class Repuesto
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public int Precio { get; set; }

        [ForeignKey("Desperfecto")]
        public int DesperfectoRefID { get; set; }

        public Desperfecto Desperfecto { get; set; }
    }
}
