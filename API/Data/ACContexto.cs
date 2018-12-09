using Find.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ACContexto:DbContext
    {
        public ACContexto(DbContextOptions<ACContexto> options)
        {}


        public DbSet <Usuario> Usuario {get; set;}
        public DbSet <Pagamento> Pagamento {get; set;}
        public DbSet <Aula> Aula {get; set;}
        public DbSet <Curso> Curso {get; set;}
        public DbSet <Acesso> Acesso {get; set;}
        public DbSet <Professor> Professor {get; set;}
        public DbSet <Nivel> Nivel {get; set;}
        public DbSet <Perguntas> Perguntas {get; set;}
        public DbSet <CursoProfessor> CursoProfessor {get; set;}

        protected override void OnModelCreating(ModelBuilder mb){
            
        }
        
    }
}