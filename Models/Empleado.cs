namespace primerApiFront.Models
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string nombre { get; set; } = "";
        public int idCargo { get; set; }
        public DateTime fechaIngreso { get; set; }
    }

}
