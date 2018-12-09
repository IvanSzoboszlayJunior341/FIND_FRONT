using System.Collections.Generic;
using System.Linq;
using Find.Data;
using Find.Models;
using Microsoft.AspNetCore.Mvc;

namespace Find.Controllers
{
    [Route("api/[controller]")]
    public class AcessoController : Controller
    {
        Acesso acess = new Acesso();

        readonly APIContexto contexto;

        public AcessoController(APIContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet("{id}")]
        public IEnumerable<object> Listar(int idCurso, int idUsuario)
        {
     
            var acessos = (from usuario in contexto.Usuario
                          join acess in contexto.Acesso on usuario.Id equals acess.idUsuario
                          join curso in contexto.Curso on acess.idCurso equals curso.Id
                          where usuario.Id == idUsuario && curso.Id == idCurso
                          select new 
                          {
                              IdUser = usuario.Id,
                              IdCur = curso.Id,
                              NomeUsuario = usuario.nomeUsuario,
                              NomeCurso = curso.nomeCurso,
                              Acesso = usuario.Acesso
                          }).OrderByDescending(a => a.Acesso).Take(1);

            var rs = acessos.ToList();

            return rs;       
        }
    }
}