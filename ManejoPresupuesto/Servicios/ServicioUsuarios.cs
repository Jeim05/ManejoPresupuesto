namespace ManejoPresupuesto.Servicios
{
    public interface IServicioUsuarios
    {
        int obtenerUsuarioId();
    }

    public class ServicioUsuarios:IServicioUsuarios
    {
        public int obtenerUsuarioId()
        {
            return 1;
        }
    }
}
