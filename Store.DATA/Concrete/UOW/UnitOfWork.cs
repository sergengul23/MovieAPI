using Store.DATA.Abstract.Repositories;
using Store.DATA.Abstract.UOW;
using Store.DATA.Concrete.EntityFramework.Contexts;
using Store.DATA.Concrete.EntityFramework.Repositories;

namespace Store.DATA.Concrete.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private MovieRepository _movieRepository;
        private DirectorRepository _directorRepository;
        private ActorRepository _actorRepository;
        private GenreRepository _genreRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IMovieRepository Movies => _movieRepository ?? new MovieRepository(_context);
        public IDirectorRepository Directors => _directorRepository ?? new DirectorRepository(_context);
        public IActorRepository Actors => _actorRepository ?? new ActorRepository(_context);
        public IGenreRepository Genres => _genreRepository ?? new GenreRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
