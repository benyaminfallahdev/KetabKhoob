
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain
{
    public class BaseEntity
    {

        public long Id { get; set; }

        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}
