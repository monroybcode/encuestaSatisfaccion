using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EncuestaSatisfaccion.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public string UltimoIngreso { get; set; }
        public string NombreCompleto { get; set; }
        public bool IndAct { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<UnidadesMedicas> UnidadesMedicas { get; set; }
        public DbSet<Funciones> Funciones { get; set; }
        public DbSet<FuncionesXRol> FuncionesXRol { get; set; }
        public DbSet<UsuarioxUmedica> UsuarioxUmedica { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }

        public DbSet<Encuestados> Encuestados { set; get; }
        public DbSet<Respuestas> Respuestas { set; get; }

        public DbSet<VigenciaEnc> VigenciaEnc { set; get; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}