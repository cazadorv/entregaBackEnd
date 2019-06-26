using Nancy;
using Nancy.TinyIoc;
namespace practica_Back_end
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer contenedor)
        {
            base.ConfigureApplicationContainer(contenedor);
            contenedor.Register<ListaClientesService>().AsSingleton();   
        }
    }
}