using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OnlineShop_API.Data;
using OnlineShop_API.IRepository;
using OnlineShop_API.Models;
using OnlineShop_API.Repository;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionStrings")));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(option=> 
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 6;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
                option.Password.RequiredUniqueChars = 0;
            });
            services.AddControllers()
                .AddNewtonsoftJson(option =>
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]))
                    
                };
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IOrederRepository, OrederRepository>(); 


            services.AddCors(options=>
            {
                options.AddDefaultPolicy(builder=>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider service)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images"
            }) ;
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            createAdmin(service).Wait();
        }

        public async Task createAdmin(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<AppUser>>();
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();


            var isUserRoleExists = await roleManager.RoleExistsAsync("User");
            var isAdminRoleExists = await roleManager.RoleExistsAsync("Admin");
            var isUserExists = await userManager.FindByEmailAsync("admin@gmail.com");
            var isModaretorRoleExists = await roleManager.RoleExistsAsync("Modaretor");

            if (isAdminRoleExists == false || isUserExists == null)
            {
                if (isAdminRoleExists == false)
                {
                    var AdminRole = new IdentityRole
                    {
                        Name = "Admin"
                    };
                    await roleManager.CreateAsync(AdminRole);
                   
                }

                if (isModaretorRoleExists == false)
                {
                    var ModaretorRole = new IdentityRole
                    {
                        Name = "Modaretor"
                    };
                    await roleManager.CreateAsync(ModaretorRole);
                }

                if (isUserRoleExists == false)
                {
                    var UserRole = new IdentityRole
                    {
                        Name = "User"
                    };
                    await roleManager.CreateAsync(UserRole);
                }

                if (isUserExists == null)
                {
                    var adminUser = new AppUser
                    {
                        firstName="Author",
                        lastName= "Author",
                        UserName = "admin",
                        Email = "admin@mail.com"
                    };

                    var result = await userManager.CreateAsync(adminUser, "123456");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
            }
        }
    }
}
