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
                    //var datos = new Cliente (1,"Fede","Giant","moreno 951");
                    
                    //declaro la direccion desde donde voya obtener el JSON
                    var url = "https://randomuser.me/api/?results=10";
                    //creo mi variable para manejar mi url
                    WebClient wc = new WebClient();
                    //almaceno los datos de esa direccion
                    var datos = wc.DownloadString(url);
                    
                    //mapeo el modelo de mi direccion                    
                    return Response.AsJson(datos);
                });
                //Put("");
                Post("/",_ =>               
                {                       
                    ObjPrueba clt = this.Bind<ObjPrueba>("aqui van los datos");
                    System.Console.WriteLine(clt);
                    
                    return Nancy.HttpStatusCode.Created;
                });

                //Delete();
            }

        }
}