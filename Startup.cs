using GraphiQl;
using Graphql.Net.ObjectGraph;
using Graphql.Net.Query;
using Graphql.Net.Repository;
using Graphql.Net.Schem;
using Graphql.Net.Service;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Splat;
using System;
using System.IO;

namespace Graphql.Net
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            AddDependency(services);
        }

        public void AddDependency(IServiceCollection services)
        {

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddScoped<AuthorService>();
            services.AddScoped<AuthorRepository>();
            services.AddScoped<AuthorQuery>();
            services.AddScoped<AuthorType>();
            services.AddScoped<BlogPostType>();
            services.AddScoped<ISchema, GraphQLDemoSchema>();
            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            

            app.UseGraphiQLServer();
            app.UseHttpsRedirection();

            app.UseRouting();

          

          
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();


            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Conversor de Temperaturas");
            });
        }
    }
}
