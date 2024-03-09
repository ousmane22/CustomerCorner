﻿using CustomerCorner.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCorner.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
