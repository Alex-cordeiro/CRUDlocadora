using CRMLocadora.Context;
using CRMLocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMLocadora.Services
{
    public class ClienteService
    {
        private readonly LocadoraContext _context;
        public ClienteService(LocadoraContext context) 
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            if (!ExisteCliente(id)) 
                return false;
            var clienteRetornado = this.FindById(id);
            _context.Remove(clienteRetornado);
            _context.SaveChanges();
            return true;
            
        }

        public List<Cliente> FindAll()
        {
            return _context.Cliente.ToList();
        }

        public Cliente FindById(int id)
        {
            return _context.Cliente.SingleOrDefault(x => x.Id.Equals(id));
        }

        public bool Save(Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { 
                throw;
            }
        }

        public bool Update(Cliente cliente)
        {
            if (!ExisteCliente(cliente.Id)) return false;

            var pessoaParaEdicao = _context.Cliente.SingleOrDefault(p => p.Equals(cliente));
            if (pessoaParaEdicao != null)
            {
                try
                {
                    _context.Entry(pessoaParaEdicao).CurrentValues.SetValues(cliente);
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

        private Boolean ExisteCliente(int id)
        {
            var cliente = _context.Cliente.SingleOrDefault(x => x.Id.Equals(id));
            if (cliente != null)
                return true;
            return false;
        }
    }
}
