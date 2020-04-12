using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork.Service.Dto
{
    public class TaskSearchDto
    {
        public int ProjectId { get; set; }
        public int TaskStatusId { get; set; }
        public int UserId { get; set; }
    }
}
