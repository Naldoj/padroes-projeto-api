namespace padroes_projeto_api.Entities;

public class TurmaEntity
{
    public Int32 Id { set; get; }
    public String? Nome { set; get; }
    public String? Professor { set; get; }
    public String? Disciplina { set; get; }
    public Int32? total_de_vagas { set; get; }
    public Int32? total_de_aluno { set; get; }
}