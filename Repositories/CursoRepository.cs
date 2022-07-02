namespace padroes_projeto_api.Repositories;

using padroes_projeto_api.Entities;

public class CursoRepository
{
    private static CursoRepository? _instance = null;
    private Dictionary<Int32, CursoEntity> cursos {set; get;}

    private CursoRepository()
    {
        this.cursos =new Dictionary<Int32, CursoEntity>();
    }

     public static CursoRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new CursoRepository();
        }

        return _instance;
    } 

    
     public void Insert(CursoEntity cursoEntity)
    {
        this.cursos.Add(cursoEntity.Id, cursoEntity);
    }

    public void Update(CursoEntity alunoEntity)
    {
        this.cursos.Remove(alunoEntity.Id);
        this.cursos.Add(alunoEntity.Id, alunoEntity);
    }

    public void Delete(Int32 id)
    {
        this.cursos.Remove(id);
    }

    public CursoEntity? Select(Int32 id)
    {
        if (this.cursos.ContainsKey(id))
        {
            return this.cursos[id];
        }

        return null;
    }

    public IEnumerable<CursoEntity> GetAll()
    {
        return this.cursos.Values;
    }

}