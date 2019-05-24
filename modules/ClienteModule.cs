using System.IO;
using System.Net.Http;
using System.Net.WebSockets;
using System.Net;
using System.Runtime.CompilerServices;
using Nancy;
using practica_Back_end;
using Clases;
using Nancy.ModelBinding;

namespace ClienteModule
{
    public class ClienteModule : NancyModule
        {
            public void enableCORS(){
                // Enable cors
            After.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                    .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                    .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
            });
                
            }
            public ClienteModule()
            {                
                enableCORS();
                Get("/prueba",_=>
                {
                    var clt = new Cliente(1,"Fede","Giant","moreno 951");                    
                    return Response.AsJson(clt);
                });
                //Put("");
                Post("/",_ =>               
                {   
                    var urlFront = "https://reqres.in/api/users";
                    //creo mi variable para manejar mi url
                    WebClient wc = new WebClient();
                    //almaceno los datos de esa direccion
                    var datosFront = wc.DownloadString(urlFront);

                    //mapeo el modelo de mi direccion
                    Cliente clt = this.Bind<Cliente>(datosFront);
                    //System.Console.WriteLine(clt);

                    return Response.AsJson(datosFront,Nancy.HttpStatusCode.Created);
                     
                });

                //Delete();
            }

        }
}