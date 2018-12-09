using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Find.Models
{
    public class Perguntas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Pergunta { get; set; }
        
        [StringLength(255)]
        public string responta { get; set; }
        

        [Required]
        [ForeignKey("Usuario")]
        public int idUserP { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int idUserR { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        [ForeignKey("Aula")]
        public int idAula { get; set; }
        public ICollection<Aula> Aula{ get;set;}



        
    }
}