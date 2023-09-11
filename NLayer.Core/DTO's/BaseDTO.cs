using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTO_s
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
