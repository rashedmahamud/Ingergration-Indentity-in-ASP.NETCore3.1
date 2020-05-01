# Ingergration-Indentity-in-ASP.NetCore-3.1
----------------------------------------------
There we added Identity in a dotnetCore-3.1  project which has no identity Implemented earlier. 

Steps:
1. Create a project with no authentication 

2. add these nuget packages
   a) Microsoft.AspNetCore.Identity
   b) Microsoft.AspNetCore.Identity.EntityFrameworkCore
   c) Microsoft.AspNetCore.Identity.UI
   d) Microsoft.EntityFrameworkCore.Design
   e) Microsoft.EntityFrameworkCore.SqlServer
   f)  Microsoft.VisualStudio.Web.BrowserLink
   g) Microsoft.VisualStudio.Web.CodeGeneration.Design
   
 3. Right Click on the project Folder then go like this way 
     a) Add->New Scaffolded Item
     b) select the Identy from the left side of the pop-up windows
     c) click add 
     d) another window will pop-up select the layout Page 
     e) override all item or chose file to override 
     f) chose dataContxt Class 
     g) click add
    Note: you will see a Area folder in the project. See all the identity cshtml pages at (Identity->Pages->Account)
  4. Create a Model in the application model folder
     namespace IndentiyTest2.Models
      {
          public class ApplicationUser : IdentityUser
          {
              public int Rating { get; set; }
              public string ProfileImageUrl { get; set; }
              public DateTime MemberSince { get; set; }
          }
      }
      
   5. Create ApplicationDbContext in the model folder 
       namespace IndentiyTest2.Models
        {
            public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
            {
                public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            }

        }
        
     6. Go to Startup.cs  and change the  ConfigureServices method accordingly 
     
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders()
              .AddDefaultUI()
              .AddDefaultTokenProviders();
        }
        
        7. Change the Configure method of Startup.cs 
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //In order to get the ASP.NET Core pipeline to recognise that a user is signed in, a call to UseAuthentication is required
            app.UseAuthentication();
            
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        
       9. Add the _loginPartial in the _layour.cshtml page in the views/Shared/_layout.cshtml
       
              <partial name="_LoginPartial" />
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
                        </li>
                    </ul>
       
       8. Run the application and you will be able to see login and Register option at the top right corner of the landing page. 
        
   
