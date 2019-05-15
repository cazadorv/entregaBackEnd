using Nancy;
using practica_Back_end;
using Clases;

namespace ClienteModule
{
    public class ClienteModule : NancyModule
        {
            public ClienteModule():base("/cliente")
            {
                Get("/", _=> 
                {  var clt = new Cliente(1,"Dante","Bunteg","Donado 300");
                    if (clt == null){
                        return HttpStatusCode.NotFound;
                    }
                    
                   return Response.AsJson(clt);
                });
                //Put("");
                Post("/",_ =>               
                {    
                    return HttpStatusCode.Created;
                });

                //Delete();
            }

        }
}