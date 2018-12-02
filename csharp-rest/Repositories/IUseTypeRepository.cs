using bos.Models;
using System.Collections.Generic;

namespace bos.Repositories
{
    public interface IUseTypeRepository
    {
        List<UseType> GetAll();
        List<UseType> SearchByName(string SearchValue);
    }
}