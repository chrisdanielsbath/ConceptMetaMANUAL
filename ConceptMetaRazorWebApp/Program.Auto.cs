/****************************
 * Program.Auto.cs
 ****************************/
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp
{
    /// <summary>
    /// Program class for the ConceptMeta Razor Web App
    /// </summary>
    public partial class Program
    {

        #region Static Methods

        /// <summary>
        /// Main Method - Entry Point to the Web App
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// This method creates the Host Builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }

        #endregion
    }
}
