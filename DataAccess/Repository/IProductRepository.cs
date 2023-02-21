﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(string id);
        public List<Product> Search(string name);
        public List<Product> AllProduct();
    }
}
