﻿using CoreStore.Shared.Commands;
using System;

namespace CoreStore.Domain.StoredContext.Commands.CustomerComands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {

        public CreateCustomerCommandResult(bool sucess, string message, object data)
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
