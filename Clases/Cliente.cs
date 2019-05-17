//en este espacio declaro las clases que voy a utilizar
namespace Clases
{
        //clase cliente 
       public class Cliente
        {
           public long Id {get; set;}
           public string Nombre { get; set;}
           public string Apellido { get; set;}
           public string Direccion { get; set;}

        //constructor para inicializar sin atributos
           public Cliente(){}
        //constructor para inicializar con atributos
           public Cliente(long id, string nombre, string apellido, string direccion)
           {
                   this.Id = id;
                   this.Nombre = nombre;
                   this.Apellido = apellido;
                   this.Direccion = direccion;
           }
        //metodos set
        public void setId(long id){
                this.Id=id;
        }
        public void setNombre(string nombre){
                this.Nombre =nombre;
        }

        public void setApellido(string apellido){
                this.Apellido = apellido;
        }
        public void setDireccion(string direccion){
                this.Direccion = direccion;
        }

        }
}