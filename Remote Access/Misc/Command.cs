using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2S
{
    public interface Command
    {
        string CommandName { get; }
        string CommandSubName { get; }
        void Execute(string command);
    }
}
