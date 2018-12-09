using System.Collections.Generic;
using System.Linq;
using Find.Data;
using Find.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Find.Controllers
{

    [Route("api/[controller]")]

    
    public class AulaController : Controller
    {
        Aula aula = new Aula();

        readonly APIContexto contexto;

        public AulaController(APIContexto contexto)
        {
            this.contexto = contexto;
        }
        // [Authorize("Bearer",Roles="Usuario")]
        [HttpGet("{id}")]
        public IEnumerable<object> Listar(int id)
        {   
            var aulas = contexto.Curso
                        .Join(contexto.Aula,
                        cur => cur.Id,
                        au => au.idCurso,
                        (cur, au) => new
                        {
                            Id = cur.Id,
                            NomeCurso = cur.nomeCurso,
                            //Requisitos = cur.Requisitos,
                            //Progresso = cur.Progresso,
                            NomeAula = au.nomeAula,
                            //Perguntas = au.Pergunta,
                            //Visto = au.vistoAula,
                            AulaCaminho = au.aulaCaminho,
                            Contexo = au.aulaContexto
                        }).Where(aul => aul.Id == id);
            var rs = aulas.ToList();

            return rs;
        }
       
        // [Authorize("Bearer",Roles="Professor")]
        [HttpPost]
        public IActionResult Cadastro([FromBody] Aula aula)
        {
            if(!ModelState.IsValid)
                return BadRequest("Não foi possível enviar os dados para o cadastro");

            contexto.Aula.Add(aula);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi porssível cadastrar!");
            else
                return Ok(aula);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] Aula aula, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest("Não foi possível atualizar os dados!");
            
            var aul = contexto.Aula.Where(au => au.Id == id).FirstOrDefault();

            aul.nomeAula = aula.nomeAula;
            aul.aulaContexto = aula.aulaContexto;
            aul.Pergunta = aula.Pergunta;
            aul.aulaCaminho = aula.aulaCaminho;
            contexto.Aula.Update(aul);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possível atualizar os dados");
            else
                return Ok(aula);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar([FromBody] Aula aula, int id)
        {
            var aul = contexto.Aula.Where(au => au.Id == id).FirstOrDefault();
            if(aul == null)
                return BadRequest("Aula não existe!");
            
            contexto.Aula.Remove(aul);
            int rs = contexto.SaveChanges();

            if(rs > 0)
                return Ok();
            else
                return BadRequest();
        }
    }
}