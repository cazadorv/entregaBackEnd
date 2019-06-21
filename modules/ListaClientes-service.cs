using System.Linq;
using System.Collections.Generic;
using Clases;

//aqui voy a declarar mis funciones o procedimientos que utilizare desde el modulo
namespace practica_Back_end
{
    public class ListaClientesService
    {
        private List<Cliente> listaCliente;
        public ListaClientesService()
        {
            //inicializo mi lista con 
            this.listaCliente = new List<Cliente>
            {
                new Cliente(0,"Carlos","Frazua","Dorbenite 2568"),
                new Cliente(1,"Ezequiel","Miravales","Claromeco 56"),
                new Cliente(2,"Francesco","Elvar","Gamorra 2")
            };
        }
        //retorna la lista de clientes    
        public List<Cliente> getClientes()
        {
            return this.listaCliente;
        }
        // genera una id nueva para un nuevo cliente
        public int generateId()
        {
            return this.listaCliente.Last().getId()+1;
        }
        public void addCliente(Cliente newCliente)
        {
            newCliente.Id = generateId();          
            this.listaCliente.Add(newCliente);            
        }

        /* retorna un cliente si existe en el listado */
        public Cliente findCliente(int id)
        {
            return listaCliente.FirstOrDefault( x => x.Id == id );
        }

        /* Si existe, elimina el cliente con ese id */
        public bool delClienteById(int id)
        {
            bool seBorro = false;
            if(findCliente(id) != null)
            {
                listaCliente.RemoveAt(id);
                seBorro = true;
            }
            return seBorro;
        }

        /* Se actualiza un cliente si existe, sino devuelve nulo */
        public void updateCliente(int id, Cliente datosNuevos)
        {
            Cliente clienteViejo = findCliente(id);

            if (clienteViejo != null)
            {
                clienteViejo.setNombre(datosNuevos.Nombre);
                clienteViejo.setApellido(datosNuevos.Apellido);
                clienteViejo.setDireccion(datosNuevos.Direccion);
            }
        }
    }
}