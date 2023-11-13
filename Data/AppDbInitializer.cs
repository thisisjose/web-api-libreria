using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using libreria_JSVE.Data.Models;
using static System.Reflection.Metadata.BlobBuilder;
using System.Threading;
using System;

namespace libreria_JSVE.Data

{
    public class AppDbInitializer
    {
        //Metodo que agrega datos a nuestra BD
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDebContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Titulo = "1st Book Title",
                        Descripcion = "2st Boom Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Biography",
                        Autor = "1st Author",
                        ConverUrl = "https...",
                        DateAdded = DateTime.Now,
                    },
                    new Book()
                    {
                        Titulo = "2nd Book Title",
                        Descripcion = "2nd Boom Description",
                        IsRead = true,
                        Rate = 4,
                        Genero = "Biography",
                        Autor = "2nd Author",
                        ConverUrl = "https...",
                        DateAdded = DateTime.Now,
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
