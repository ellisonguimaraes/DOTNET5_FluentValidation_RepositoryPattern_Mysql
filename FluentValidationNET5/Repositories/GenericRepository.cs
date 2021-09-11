using System;
using System.Data;
using System.Collections.Generic;
using FluentValidationNET5.Models;
using FluentValidationNET5.Models.Context;
using FluentValidationNET5.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FluentValidationNET5.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dataset;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public List<T> GetAll() => _dataset.ToList();

        public T GetById(long id) => _dataset.SingleOrDefault(i => i.Id.Equals(id));

        public T Create(T obj)
        {
            try {
                _dataset.Add(obj);
                _context.SaveChanges();
                return obj;
            } catch (Exception) {
                throw;
            }
        }

        public T Update(T obj)
        {
            var result = _dataset.SingleOrDefault(i => i.Id.Equals(obj.Id));

            if(result != null)
            {
                try {
                    _context.Entry(result).CurrentValues.SetValues(obj);
                    _context.SaveChanges();
                    return result;

                } catch(Exception) {
                    throw;
                }
            }
            return null;
        }

        public bool Delete(long id)
        {
            var result = _dataset.SingleOrDefault(i => i.Id.Equals(id));

            if (result != null) {
                try {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                    return true;

                } catch (Exception) {
                    throw;
                }
            }
            
            return false;
        }
    }
}