using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System;
using System.IO;
using System.Net.Http;
using System.Net.WebSockets;
using System.Net;
using System.Runtime.CompilerServices;
using Nancy.ModelBinding;
using Nancy;
using Clases;

namespace practica_Back_end
{
    public class ClienteModule : NancyModule
        {
            //creo una variable para poder usar mis servicio
            private ListaClientesService _servicioListaCliente;
            //creo una tupla para poder activar el control de acceso CORS
            private Tuple<string, string>[] CorsHeaders = { 
                                        Tuple.Create("Access-Control-Allow-Origin", "*"), 
                                        Tuple.Create("Access-Control-Allow-Headers", "Accept, Origin, Content-type"),
                                        Tuple.Create("Access-Control-Allow-Methods", "GET,HEAD,POST,DELETE,OPTIONS,PUT,PATCH")
            };
        public ClienteModule(ListaClientesService servicioLC)
            {    
                //activo el CORS
                After += ctx => ctx.Response.WithHeaders(CorsHeaders);
                //se crea una variable del servicio
                this._servicioListaCliente = servicioLC;    
                //se crea la variable listado
                List<Cliente> listado = servicioLC.getClientes();  
                
                //se muestran todos los clientes del listado
                Get("/cliente",_=>
                {
                    return Response.AsJson(listado);
                });
                //se muestra un cliente del listado, pasando su posicion
                //Get("/cliente/{id}", id =>
                //{
                //    Cliente mostrar= servicioLC.getCliente(id);
                //    return Response.AsJson(mostrar);
                //});
                Post("/clientes/posteo", _ =>
                {
                    var lista = this.Bind<Cliente>();
                    _servicioListaCliente.addCliente(lista);
                    return Response.AsJson(lista);
                });
                
                Post("/clientes/posteo1",_ =>               
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
            //public void enableCORS(){            
            // Enable cors
            //After.AddItemToEndOfPipeline((ctx) =>
            //{
            //    ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
            //        .WithHeader("Access-Control-Allow-Methods", "POST,GET")
            //        .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
            //});