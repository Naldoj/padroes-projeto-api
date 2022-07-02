namespace padroes_projeto_api.Services;

using padroes_projeto_api.Entities;
using padroes_projeto_api.Repositories;


public class CursoService
{
    private static CursoService? _instance = null;

    private CursoRepository cursoRepository;

    private CursoService()
    {
        this.cursoRepository = CursoRepository.GetInstance();
    }

    public static CursoService GetInstance()
    {
        if (_instance == null)
        {
            _instance = new CursoService();
        }

        return _instance;
    }

    public CursoEntity? Insert(CursoEntity cursoEntity)
    {
        if (this.cursoRepository.Select(cursoEntity.Id) != null)
        {
            return null;
        }

        this.cursoRepository.Insert(cursoEntity);

        return cursoEntity;
    }

    public CursoEntity? Update(CursoEntity cursoEntity)
    {
        if (this.cursoRepository.Select(cursoEntity.Id) != null)
        {
            this.cursoRepository.Update(cursoEntity);

            return null;
        }

        return cursoEntity;
    }

    public CursoEntity? Delete(Int32 id)
    {
        CursoEntity? cursoEntity = this.cursoRepository.Select(id);

        if (cursoEntity !=null)
        {
            this.cursoRepository.Delete(id);

            return cursoEntity;
        }

        return null;
    }

    public CursoEntity? Select(Int32 id)
    {
        return this.cursoRepository.Select(id);
        
    }

    public IEnumerable<CursoEntity> GetAll()
    {
        return this.cursoRepository.GetAll();
    }
}