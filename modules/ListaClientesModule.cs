using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Nancy;
using Nancy.Owin;
using practica_Back_end;
using Clases;

namespace ListadoDeClientes
{
    public class ListaCLientesModule:NancyModule
    {
        List<Cliente> listaCliente;
        public void InicializarLista(){
            this.listaCliente = new List<Cliente>();
        }
        public void addCliente(Cliente newClient){
            this.listaCliente.Add(newClient);
            
        }
        
        public void getCliente(int id){
            System.Console.WriteLine("dentro de get cliente");
        }
    }
}