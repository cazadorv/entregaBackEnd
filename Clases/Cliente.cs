using System;
//en este espacio declaro las clases que voy a utilizar
namespace Clases
{
        //clase cliente 
        [Serializable]
       public class Cliente
        {
           public int Id {get; set;}
           public string Nombre { get; set;}
           public string Apellido { get; set;}
           public string Direccion { get; set;}

        /*constructor para inicializar sin atributos */
           public Cliente(){}

        /*constructor para inicializar con atributos*/
           public Cliente(int id, string nombre, string apellido, string direccion)
           {
                   this.Id = id;
                   this.Nombre = nombre;
                   this.Apellido = apellido;
                   this.Direccion = direccion;
           }

            /*Metodos get de los atributos*/
            public int getId() { return Id; }
            public String getNombre() { return Nombre; }
            public String getApellido() { return Apellido; }
            public String getDireccion() { return Direccion; }

            /*Metodos set de los atributos*/
            public void setId(int i) { Id = i; }
            public void setNombre(string nom) { Nombre = nom; }
            public void setApellido(string ape) { Apellido = ape; }
            public void setDireccion(string dire) { Direccion = dire; }
        }
}