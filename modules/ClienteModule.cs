using System.Collections.Generic;
using System;
using System.Net;
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
        public ClienteModule(ListaClientesService servicioLC):base("/cliente")
            {    
                //activo el CORS
                After += ctx => ctx.Response.WithHeaders(CorsHeaders);
                
                //se crea una variable del servicio
                this._servicioListaCliente = servicioLC;      
                                
                //se muestran todos los clientes del listado
                Get("/",_=>
                {   
                    return Response.AsJson(servicioLC.getClientes());
                });
                
                //obtengo los datos desde la URL
                Post("/nuevo", _ =>
                {
                    var nuevoClt = this.Bind<Cliente>();
                    _servicioListaCliente.addCliente(nuevoClt);
                    return Response.AsJson(servicioLC.getClientes());
                });

                /*Post("/crearNvo",_ =>               
                {   
                    var urlFront = "http://localhost:4200";

                    //creo mi variable para manejar mi url
                    WebClient wc = new WebClient();
                    //almaceno los datos de esa direccion
                    var datosFront = wc.DownloadString(urlFront);

                    //mapeo el modelo de mi direccion
                    var clt = this.Bind<Cliente>(datosFront);
                    //System.Console.WriteLine(clt);
                    _servicioListaCliente.addCliente(clt);
                    return Response.AsJson(datosFront,Nancy.HttpStatusCode.Created);
                     
                });
                */
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