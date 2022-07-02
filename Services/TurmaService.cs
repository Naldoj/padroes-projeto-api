namespace padroes_projeto_api.Services;

using padroes_projeto_api.Entities;
using padroes_projeto_api.Repositories;



public class TurmaService
{
    private static TurmaService? _instance = null;

    private TurmaRepository turmaRepository;

    private TurmaService()
    {
        this.turmaRepository = TurmaRepository.GetInstance();
    }

    public static TurmaService GetInstance()
    {
        if (_instance == null)
        {
            _instance = new TurmaService();
        }

        return _instance;
    }

    public TurmaEntity? Insert(TurmaEntity turmaEntity)
    {
        if (this.turmaRepository.Select(turmaEntity.Id) != null)
        {
            return  null;
        }

        this.turmaRepository.Insert(turmaEntity);

        return turmaEntity;
    }

    public TurmaEntity? Update(TurmaEntity turmaEntity)
    {
        if (this.turmaRepository.Select(turmaEntity.Id) != null)
        {
            this.turmaRepository.Update(turmaEntity);

            return turmaEntity;
        }

        return null;
    }

    public TurmaEntity? Delete(Int32 id)
    {
        TurmaEntity? turmaEntity =this.turmaRepository.Select(id);

        if (turmaEntity!= null)
        {
            this.turmaRepository.Delete(id);

            return turmaEntity;
        }

        return null;
    }

    public TurmaEntity? Select(Int32 id)
    {
        return this.turmaRepository.Select(id);
    }
     public IEnumerable<TurmaEntity> GetAll()
    {
        return this.turmaRepository.GetAll();
    }


}