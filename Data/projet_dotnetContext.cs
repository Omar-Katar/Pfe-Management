using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projet_dotnet.Models;

namespace projet_dotnet.Data
{
    public class Projet_dotnetContext : DbContext
    {
        public Projet_dotnetContext (DbContextOptions<Projet_dotnetContext> options)
            : base(options)
        {
        }

        public DbSet<projet_dotnet.Models.Enseignant> Enseignant { get; set; } = default!;
        public DbSet<projet_dotnet.Models.Etudiant> Etudiant { get; set; } = default!;
        public DbSet<projet_dotnet.Models.Pfe> Pfe { get; set; } = default!;
        public DbSet<projet_dotnet.Models.Pfe_Etudiant> Pfe_Etudiant { get; set; } = default!;
        public DbSet<projet_dotnet.Models.Societe> Societe { get; set; } = default!;
    }
}
