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
                new Cliente(1,"Francesco","Elvar","Gamorra 2")
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
            int ultimo = this.listaCliente.Count-1;
            ultimo += 1;
            return ultimo;
        }
        public void addCliente(Cliente newCliente)
        {
            newCliente.Id = generateId();          
            this.listaCliente.Add(newCliente);            
        }

        /* retorna un cliente si existe en el listado */
        public Cliente findCliente(int id)
        {
            int posAct =0;
            bool existe = false;
            Cliente clienteAct = null;

            while (posAct < listaCliente.Count && !existe)
            {
                if (listaCliente.ElementAt(posAct).Id.Equals(id))
                {
                    clienteAct = listaCliente.ElementAt(posAct);
                    existe = true;
                }
                posAct++;
            }
            return clienteAct;
        }
        /* Devuelve un cliente de una determinada posicion, sino existe de vuelve null */
        public Cliente getClienteById(int id)
        {
            return findCliente(id);            
        }

        /* elimina la lista de clientes */
        public void delClientes(){
            listaCliente.Clear();
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
        public Cliente updateCliente(int id,string nvoNom, string nvoApe, string nvoDir)
        {
            Cliente clt = findCliente(id);

            if (clt != null)
            {
                clt.setNombre(nvoNom);
                clt.setApellido(nvoApe);
                clt.setDireccion(nvoDir);
            }

            return clt;
        }
    }
}