using Store.DATA.Abstract.Repositories;

namespace Store.DATA.Abstract.UOW
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IMovieRepository Movies { get; }
        IDirectorRepository Directors { get; }
        IActorRepository Actors { get; }
        IGenreRepository Genres { get; }
        Task<int> SaveAsync();
    }
}
