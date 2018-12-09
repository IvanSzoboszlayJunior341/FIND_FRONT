using System.Collections.Generic;
using System.Linq;
using Find.Data;
using Find.Models;
using Microsoft.AspNetCore.Mvc;

namespace Find.Controllers
{
    [Route("api/[controller]")]
    public class ProfessorController : Controller
    {
        Professor prof = new Professor();

        readonly APIContexto contexto;

        public ProfessorController(APIContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Professor> Listar()
        {
            return contexto.Professor.ToList();
        }

        [HttpGet("{id}")]
        public Professor Listar(int id)
        {
            return contexto.Professor.Where(prof => prof.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Professor professor)
        {
            if(!ModelState.IsValid)
                return BadRequest("Não foi possível enviar os dados, pois não seguem o padrão de cadastro");

            contexto.Professor.Add(professor);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possível cadastrar");
            else
                return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] Professor professor, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest("Não foi possível atualizar os dados, pois não seguem o padrão de atualização");

            var prof = contexto.Professor.Where(pro => pro.Id == id).FirstOrDefault();

            prof.nomeProfessor = professor.nomeProfessor;
            prof.Email = professor.Email;
            prof.Senha = professor.Senha;
            contexto.Professor.Update(prof);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possível atualizar");
            else
                return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar([FromBody] Professor professor, int id)
        {
            var prof = contexto.Professor.Where(pro => pro.Id == id).FirstOrDefault();
            if(prof == null)
                return BadRequest("Professor não encontrado!");
            
            contexto.Professor.Remove(prof);
            int rs = contexto.SaveChanges();

            if(rs > 0)
                return Ok();
            else
                return BadRequest();
        }
    }
}