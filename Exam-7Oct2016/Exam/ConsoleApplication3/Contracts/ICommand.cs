using System.Collections.Generic;

namespace ConsoleApplication3.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
