﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHJZDJ_HFT_2023242.Repository.Interface
{
    internal interface IRepository<T> where T : class
    {
        IQueryable<T> ReadAll();
        T Read(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
