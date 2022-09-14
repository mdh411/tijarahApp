using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get; }      // T is type and bool is what it returns // Criteria is like a 'where' clause
        List<Expression<Func<T, object>>> Includes {get; } 
    }
}