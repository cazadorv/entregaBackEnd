using System.Net.Http;
using System.Net.WebSockets;
using System.Net;
using System.Runtime.CompilerServices;
using Nancy;
using practica_Back_end;
using Clases;
using Nancy.ModelBinding;
using ObjetosPrueba;

namespace ClienteModule
{
    public class ClienteModule : NancyModule
        {
            public ClienteModule():base("/cliente")
            {
                Get("/", _=> 
                {  
                    //var clt = new Cliente(1,"Carlos","Ferrer","Holdich 56");
                    //declaro la direccion desde donde voya obtener el JSON
                    var url = "https://randomuser.me/api/?results=30";
                    //creo mi variable para manejar mi url
                    WebClient wc = new WebClient();
                    //almaceno los datos de esa direccion
                    var datos = wc.DownloadString(url);
                    //mapeo el modelo de mi direccion
                    ObjPrueba clt = this.Bind<ObjPrueba>(datos);
                    
                    if (clt == null){
                        System.Console.WriteLine("entre al if");
                        return Nancy.HttpStatusCode.NotFound;
                    }
                   return Response.AsJson(clt);
                });
                //Put("");
                Post("/",_ =>               
                {   
                    System.Console.WriteLine("entre /POST"); 
                    return Nancy.HttpStatusCode.Created;
                });

                //Delete();
            }

        }
}