namespace padroes_projeto_api.Repositories;

using padroes_projeto_api.Entities;

public class TurmaRepository
{
    private static TurmaRepository? _instance = null;
    private Dictionary<Int32, TurmaEntity> turma {set; get;}

    private TurmaRepository()
    {
        this.turma =new Dictionary<Int32, TurmaEntity>();
    }

     public static TurmaRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new TurmaRepository();
        }

        return _instance;
    } /////////
    //////////
     public void Insert(TurmaEntity turmaEntity)
    {
        this.turma.Add(turmaEntity.Id, turmaEntity);
    }

    public void Update(TurmaEntity turmaEntity)
    {
        this.turma.Remove(turmaEntity.Id);
        this.turma.Add(turmaEntity.Id, turmaEntity);
    }

    public void Delete(Int32 id)
    {
        this.turma.Remove(id);
    }

    public TurmaEntity? Select(Int32 id)
    {
        if (this.turma.ContainsKey(id))
        {
            return this.turma[id];
        }

        return null;
    }
    public IEnumerable<TurmaEntity> GetAll()
    {
        return this.turma.Values;
    }

}