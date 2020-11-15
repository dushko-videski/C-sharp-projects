using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public abstract string Info();
    }
}
