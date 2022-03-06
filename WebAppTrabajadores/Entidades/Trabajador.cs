using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTrabajadores.Entidades
{
    public class Trabajador
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido") ]
        [StringLength(maximumLength:10, ErrorMessage = "El campo {0} solo puede tener hasta 10 caracteres")]
        public string Nombre { get; set; }
        [Range(18,100)]
        [NotMapped]
        public int Edad { get; set; }
        //[CreditCard] valida que tenga 16 numeros como en las tarjetas
        [NotMapped]
        public string Tarjeta { get; set; }

        //[Url] debe tener una sintaxis de pagina web
        [NotMapped]

        public List<Puesto> Puestos { get; set; }
    }
}
