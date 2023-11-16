using ALUMNO_PIA.Models;

namespace ALUMNO_PIA.Servicios
{
    public interface Registrar_Alumno_API
    {
        Task<List<Alumno>> Lista();
        Task<Alumno> Obtener(int IdMatricula);
        Task<bool> Guardar(Alumno objeto);
        Task<bool> Editar(Alumno objeto);
        Task<bool> Eliminar(int IdMatricula);






    }
}
