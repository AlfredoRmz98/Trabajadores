namespace WebAppTrabajadores.Entidades
{
    public class Puesto
    {
        public int Id { get; set; }
        public string Nombre { get; set;}

        public string Departamento { get; set;}

        public int TrabajadorId { get; set; }
        public Trabajador Trabajador { get; set; }


    }
}
