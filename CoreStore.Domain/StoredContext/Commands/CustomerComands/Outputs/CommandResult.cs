using CoreStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext.Commands.CustomerComands.Outputs
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
