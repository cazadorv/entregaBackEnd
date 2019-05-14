using System.Collections.Generic;
using System.Collections;//referencia para el arraylist
using Nancy;
using Nancy.Owin;

namespace practica_Back_end
{
    public class ListaCLientesModule:NancyModule
    {
        List<Cliente> listaCliente;
        public void InicializarLista(){
            this.listaCliente = new List<Cliente>();
        }
    }
}