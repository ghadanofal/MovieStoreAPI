﻿using Ecommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task <IEnumerable<T>> GetAll(Expression<Func<T,bool>> filter = null, int page_Size = 2, int page_Number = 1, string? includeProperity = null);
        public Task <T> GetById(int id);
        public Task Create(T request);
        public void update(T request);
        public Task Delete(int id);
    }
}
