using Nancy;

namespace Cliente
{
       public class ClienteModulo : NancyModule
        {
           public long Id {get; set;}
           public string Nombre { get; set;}
           public string Apellido { get; set;}
           public string Direccion { get; set;}
           
           public ClienteModulo(long id, string nombre, string apellido, string direccion)
           {
                   this.Id = id;
                   this.Nombre = nombre;
                   this.Apellido = apellido;
                   this.Direccion = direccion;
           }
        }
}