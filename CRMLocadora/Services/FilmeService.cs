using CRMLocadora.Context;
using CRMLocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMLocadora.Services
{
    public class FilmeService
    {
        private readonly LocadoraContext _context;

        public FilmeService(LocadoraContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            if (!ExisteFilme(id))
                return false;
            var clienteRetornado = this.FindById(id);
            _context.Remove(clienteRetornado);
            _context.SaveChanges();
            return true;

        }

        public List<Filme> FindAll()
        {
            return _context.Filme.ToList();
        }

        public Filme FindById(int id)
        {
            return _context.Filme.SingleOrDefault(x => x.Id.Equals(id));
        }

        public bool Save(Filme filme)
        {
            try
            {
                _context.Add(filme);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Update(Filme filme)
        {
            if (!ExisteFilme(filme.Id)) return false;

            var filmeParaEdicao = _context.Cliente.SingleOrDefault(p => p.Equals(filme));
            if (filmeParaEdicao != null)
            {
                try
                {
                    _context.Entry(filmeParaEdicao).CurrentValues.SetValues(filme);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return false;

        }

        private Boolean ExisteFilme(int id)
        {
            var filme = _context.Filme.SingleOrDefault(x => x.Id.Equals(id));
            if (filme != null)
                return true;
            return false;
        }
    }
}
