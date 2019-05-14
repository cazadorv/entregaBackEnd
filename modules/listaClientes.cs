using Nancy;
using Nancy.Owin;

namespace practica_Back_end
{
    public class ClienteModule : NancyModule
        {
            public ClienteModule():base("/cliente")
            {
                Get("/", _=> 
                {  var clt = new Cliente(1,"Dante","Bunteg","En Tokio ahora al 3000000");
                   return Response.AsJson(clt);
                });
                //Put("");
                Post("/",_ =>
                {
                    var datos = this.Request.Body.ToString();
                    return HttpStatusCode.OK;//Response.AsJson(datos);
                });

                //Delete();
            }

        }
}