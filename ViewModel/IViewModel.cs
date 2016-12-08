using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public interface IViewModel<T>
    {
        T Model{ get; }
        bool IsViewModelOf(T model);
        void LoadFrom(T model);
    }
}
