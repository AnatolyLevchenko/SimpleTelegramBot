using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnekdotBot.Services
{
    public interface IJoke
    {
        Task<string> Get(Category cat);
    }
}
