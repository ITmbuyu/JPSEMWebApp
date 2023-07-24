using Microsoft.AspNetCore.Components.Routing;

namespace JPSEMWebApp.Models
{
    public class Router
    {
        public  int RouterId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double OnceOffPrice { get; set; }
    }
}
