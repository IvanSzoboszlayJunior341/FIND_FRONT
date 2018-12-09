using System.Collections.Generic;
using System.Linq;
using Find.Data;
using Find.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Find.Controllers
{
    
    public class CursoController : Controller
    {
        Curso cur = new Curso();

        readonly APIContexto contexto;

        public CursoController(APIContexto contexto)
        {
            this.contexto = contexto;
        }  
        [Route("api/curso")]
         [HttpGet]
        public IEnumerable<Curso> Listar()
        {
            return contexto.Curso.ToList();
        } 
        
        [Route("api/curso/{id}")]
        [HttpGet("{id}")]
        public Curso Listar(int id)
        {
            return contexto.Curso.Where(cur => cur.Id == id).FirstOrDefault();
        }
    

        
        //==========================================================================================
        [Route("api/cucub")]
        [HttpGet]
        public IEnumerable<Curso> Listar2()
        {
            var rs = contexto.Curso.Where(x => x.Categoria == "Banco de Dados").ToList();
            return rs;
        }
        [Route("api/curmo")]
        public IEnumerable<Curso> Listar3()
        {
            var rs = contexto.Curso.Where(x => x.Categoria == "Mobile").ToList();
            return rs;
        }
        [Route("api/curpro")]
        public IEnumerable<Curso> Listar4()
        {
            var rs = contexto.Curso.Where(x => x.Categoria == "Programação").ToList();
            return rs;
        }
        [Route("api/curfro")]
        public IEnumerable<Curso> Listar5()
        {
            var rs = contexto.Curso.Where(x => x.Categoria == "Front-end").ToList();
            return rs;
        }
        [Route("api/curbac")]
        public IEnumerable<Curso> Listar6()
        {
            var rs = contexto.Curso.Where(x => x.Categoria == "Back-End").ToList();
            return rs;
        }
        [Route("api/curinf")]
        public IEnumerable<Curso> Listar7()
        {
            var rs = contexto.Curso.Where(x => x.Categoria == "infraestrutura").ToList();
            return rs;
        }

        //==========================================================================================


        // [Authorize("Bearer",Roles="professor")]
        [Route("api/curso")]
        [HttpPost]
        public IActionResult Cadastro([FromBody] Curso curso)
        {
            if(!ModelState.IsValid)
                return BadRequest("Não foi possível enviar os dados para o cadastro, pois os dados não seguem o padrão de cadastro");

            contexto.Curso.Add(curso);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possível cadastrar");
            else
                return Ok(curso);
        }
        
        [Route("api/curso/{id}")]
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] Curso curso, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest("Não foi possível atualizar os dados, pois eles não seguem o padrão de atualização!");
            
            var cur = contexto.Curso.Where(cr => cr.Id == id).FirstOrDefault();
            
            cur.nomeCurso = curso.nomeCurso;
            cur.Requisitos = curso.Requisitos;
            cur.Progresso = curso.Progresso;
            cur.Categoria = curso.Categoria;
            cur.CursoProfessor = curso.CursoProfessor;
            contexto.Curso.Update(cur);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possível atualizar!");
            else
                return Ok(curso);
        }

        
    }
}