using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext.Services
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string body);
    }
}
