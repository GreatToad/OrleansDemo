using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IHelloGrain : IGrainWithIntegerKey
    {
        Task<List<UserDTO>> List(Expression<Func<UserDTO, bool>> expr);

        Task<string> Test(UserDTO dto);
    }
}
