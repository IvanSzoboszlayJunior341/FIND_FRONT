using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Find.Models
{
    public class Nivel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public bool Acessado { get; set; }
        [Required]
        public string Quantidade { get; set;}

        [Required]
        [ForeignKey("Usuario")]
        public int idUser { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        [ForeignKey("Aula")]
        public int idAula {get;set;}
        public Aula Aula {get;set;}

    }
}