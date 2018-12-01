using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TagExamples.Startup))]
namespace TagExamples
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
