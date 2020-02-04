using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Shared.Commands
{
    public interface ICommandResult
    {
        bool Sucess { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
