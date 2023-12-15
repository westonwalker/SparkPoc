using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Spark.Library.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static string Route(this NavigationManager navManager)
        {
            return navManager.ToBaseRelativePath(navManager.Uri);
        }
        
        public static void XNavigateTo(this NavigationManager navManager, HttpContext context, string url)
        {
            context.Response.Headers.Append("HX-Location", url);
        }
    }
}
