using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        //isme göre aratılan kategoriyi getirir
        Category CategoryByName(string name);
    }
}
