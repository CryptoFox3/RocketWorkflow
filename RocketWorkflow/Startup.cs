using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RocketWorkflow.Models;

[assembly: OwinStartupAttribute(typeof(RocketWorkflow.Startup))]
namespace RocketWorkflow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        private void CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Client"))
            {
                var role = new IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("OfficeAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "OfficeAdmin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Paraprofessional"))
            {
                var role = new IdentityRole();
                role.Name = "Paraprofessional";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Accountant"))
            {
                var role = new IdentityRole();
                role.Name = "Accountant";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

        }
    }
}
