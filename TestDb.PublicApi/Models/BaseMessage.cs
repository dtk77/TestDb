using System;

namespace TestDb.PublicApi.Models
{
    public class BaseMessage
    {
        protected Guid _correlationId = Guid.NewGuid();
        public Guid CorrelationId() => _correlationId;
    }
}
