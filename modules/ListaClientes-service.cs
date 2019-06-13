using System.Net.Security;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Nancy;
using Nancy.Owin;
using Clases;

//aqui voy a declarar mis funciones o procedimientos que utilizare desde el modulo
namespace practica_Back_end
{
    public class ListaClientesService
    {
        private List<Cliente> listaCliente;
        public ListaClientesService(){
            //inicializo mi lista con 
            this.listaCliente = new List<Cliente>
            {
                new Cliente(0,"Carlos","Frazua","Dorbenite 2568"),
                new Cliente(1,"Ezequiel","Miravales","Claromeco 56"),
                new Cliente(2,"Richard","Christoff","Misticofer 89"),
                new Cliente(3,"Raul","Kelving","Puerto alto 53"),
                new Cliente(4,"Alejandro","Raule","Francia 105"),
            };
        }
        //retorna la lista de clientes    
        public List<Cliente> getClientes(){
        return this.listaCliente;
    }
        // genera una id nueva para un nuevo cliente
        public int generateId(){
            int ultimo = this.listaCliente.Count-1;
            ultimo += 1;
            return ultimo;
        }
        public void addCliente(Cliente newCliente){
            newCliente.Id = generateId();          
            this.listaCliente.Add(newCliente);            
        }
        
        public Cliente getCliente(int pos){            
            return this.listaCliente[pos];
        }
    }
}