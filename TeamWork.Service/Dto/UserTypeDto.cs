using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork.Service.Dto
{
    public class UserTypeDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
