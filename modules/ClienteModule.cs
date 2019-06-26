using System;
using Nancy.ModelBinding;
using Nancy;
using Clases;

namespace practica_Back_end
{
    public class ClienteModule : NancyModule
        {
            /*creo una variable para poder usar mis servicio */
            private ListaClientesService _servicioListaCliente;
            /*creo una tupla para poder activar el control de acceso CORS */
            private Tuple<string, string>[] CorsHeaders = { 
                                        Tuple.Create("Access-Control-Allow-Origin", "*"), 
                                        Tuple.Create("Access-Control-Allow-Headers", "Accept, Origin, Content-type"),
                                        Tuple.Create("Access-Control-Allow-Methods", "GET,HEAD,POST,DELETE,OPTIONS,PUT,PATCH")
            };
        public ClienteModule(ListaClientesService servicioLC):base("/cliente")
            {    
                /*activo el CORS */
                After += ctx => ctx.Response.WithHeaders(CorsHeaders);
                
                /*se crea una variable del servicio */
                this._servicioListaCliente = servicioLC;      
                                
                /*se muestran todos los clientes del listado */
                Get("/",_=>
                {   
                    return Response.AsJson(servicioLC.getClientes(),HttpStatusCode.OK);
                });

                /*se muestra un cliente obtenido por su ID */
                Get("/{id}", variables =>
                {                       
                    Cliente cliente = servicioLC.findCliente(variables.id);
                    if (cliente == null )
                    {   
                        /*sino encuentro el cliente seteo el status en 404 */
                        return new Response{ StatusCode = HttpStatusCode.NotFound};
                    }
                    return Response.AsJson(cliente,HttpStatusCode.Created);
                });
                
                /*mapeo los datos enviados y creo un nuevo cliente */
                Post("/", _ =>
                {
                    var nuevoClt = this.Bind<Cliente>();
                    servicioLC.addCliente(nuevoClt);                    
                    return Response.AsJson(servicioLC.getClientes(),HttpStatusCode.Created);
                });

                /* Actualizo un cliente existente */
                Put("/{id}", variables =>
                {
                    var nuevoClt = this.Bind<Cliente>();
                    if (servicioLC.findCliente(variables.id) != null)
                    {
                        servicioLC.updateCliente(variables.id,nuevoClt);
                        return Response.AsJson(servicioLC.getClientes(),HttpStatusCode.OK);
                    }
                    return HttpStatusCode.NoContent;
                });

                /* Elimino un cliente de la lista */
                Delete("/{id}", variables =>
                {   
                    if (servicioLC.delClienteById(variables.id))
                    {
                        return Response.AsJson(servicioLC.getClientes(),HttpStatusCode.OK);
                    }
                        /* SI el cliente no existe, se devuelve un 404 */
                        return HttpStatusCode.NotFound;
                });
            }
                
        }
}