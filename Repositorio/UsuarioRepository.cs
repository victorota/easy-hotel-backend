using System.Collections.Generic;
using System.Linq;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiDbContext _contexto;
        public UsuarioRepository(ApiDbContext ctx)
        {
            _contexto = ctx;
        }
        void IUsuarioRepository.Add(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        Usuario IUsuarioRepository.Find(long id)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        }

        IEnumerable<Usuario> IUsuarioRepository.GetAll()
        {
            return _contexto.Usuarios.ToList();
        }

        void IUsuarioRepository.Remove(long id)
        {
            var entity = _contexto.Usuarios.First(u => u.UsuarioId == id);
            _contexto.Usuarios.Remove(entity);
            _contexto.SaveChanges();
        }

        void IUsuarioRepository.Update(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }
    }
}