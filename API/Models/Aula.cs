using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Find.Models
{
    public class Aula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string nomeAula { get; set;}

        [Required]
        [StringLength(255, ErrorMessage = "A aula deve ter uma prévia de até 255 caracteres.")]       
        public string aulaContexto { get; set; }

        [Required]
        [StringLength(255)]
        public string aulaCaminho { get; set; }
        public string vistoAula { get; set; }
        [ForeignKey("idCurso")]
        public int idCurso { get; set; }
        public Curso Curso { get; set; }
        public ICollection<Pergunta> Pergunta { get; set; }
    }
}