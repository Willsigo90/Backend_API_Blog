using Microsoft.OpenApi.Models;

namespace JwtApp
{
    internal class Info : OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}