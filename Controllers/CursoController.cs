using Microsoft.AspNetCore.Mvc;
using padroes_projeto_api.Entities;
using padroes_projeto_api.Views;
using padroes_projeto_api.Services;



///
///
///Onde tem matricula deve ter id
namespace padroes_projeto_api.Controllers;

[ApiController]
[Route("Cursos")]
public class CursoController : ControllerBase
{
    private CursoService cursoService;

    public CursoController()
    {
        this.cursoService = CursoService.GetInstance();
    }

    [HttpPost]
    public IActionResult Insert(CursoEntity cursoEntity)
    {
        CursoEntity? result = this.cursoService.Insert(cursoEntity);

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(500, "Curso já cadastrado");
    }

    [HttpPut("{matricula}")]
    public IActionResult Update([FromRoute] Int32 id, CursoEditView cursoEditView)
    {
        CursoEntity? result = this.cursoService.Update(new CursoEntity
        {
            Id = id,
            Nome = cursoEditView.Nome
        });

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(404, "Curso não encontrado");
    }

    [HttpDelete("{matricula}")]
    public IActionResult Delete([FromRoute] Int32 matricula)
    {
        CursoEntity? result = this.cursoService.Delete(matricula);

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(404, "Curso não encontrado");
    }

    [HttpGet]
    public IEnumerable<CursoEntity> GetAll()
    {
        return this.cursoService.GetAll();
    }

    [HttpGet("{matricula}")]
    public IActionResult GetByMatricula([FromRoute] Int32 matricula)
    {
        CursoEntity? result = this.cursoService.Select(matricula);

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(404, "Curso não encontrado");
    }
}