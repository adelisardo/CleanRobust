using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanRobust.Domain.Common;
public abstract class EntityBase
{
    public Guid Id { get; set; }
}
