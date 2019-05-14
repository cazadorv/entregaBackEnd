using Nancy;

namespace practica_Back_end
{
    public class ClienteModule : NancyModule
        {
            public ClienteModule():base("/cliente")
            {
                Get("/", _=> 
                {  var clt = new Cliente(1,"Dante","Bunteg","En Tokio ahora al 3000000");
                    if (clt == null){
                        return HttpStatusCode.NotFound;
                    }
                   return Response.AsJson(clt);
                });
                //Put("");
                Post("/",_ =>
                {
                    //var nuevo =
                    return HttpStatusCode.Created;
                });

                //Delete();
            }

        }
}