using Microsoft.AspNetCore.Mvc;
using padroes_projeto_api.Entities;
using padroes_projeto_api.Views;
using padroes_projeto_api.Services;

namespace padroes_projeto_api.Controllers;

[ApiController]
[Route("Turmas")]
public class TurmaController : ControllerBase
{
    private TurmaService turmaService;

    public TurmaController()
    {
        this.turmaService = TurmaService.GetInstance();
    }

    [HttpPost]
    public IActionResult Insert(TurmaEntity turmaEntity)
    {
        TurmaEntity? result = this.turmaService.Insert(turmaEntity);

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(500, "Turma já cadastrado");
    }

    [HttpPut("{matricula}")]
    public IActionResult Update([FromRoute] Int32 id, TurmaEditView turmaEditView)
    {
        TurmaEntity? result = this.turmaService.Update(new TurmaEntity
        {
            Id = id,
            Nome = turmaEditView.Nome
        });

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(404, "Turma não encontrado");
    }

    [HttpDelete("{matricula}")]
    public IActionResult Delete([FromRoute] Int32 matricula)
    {
        TurmaEntity? result = this.turmaService.Delete(matricula);

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(404, "Turma não encontrado");
    }

    [HttpGet]
    public IEnumerable<TurmaEntity> GetAll()
    {
        return this.turmaService.GetAll();
    }

    [HttpGet("{matricula}")]
    public IActionResult GetByMatricula([FromRoute] Int32 matricula)
    {
        TurmaEntity? result = this.turmaService.Select(matricula);

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(404, "Turma não encontrado");
    }
}