using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork.Service.Dto
{
    public class ProjectDto : BaseDto
    {
        public ProjectDto()
        {
        }

        [Required(ErrorMessage = "Proje adı boş geçilemez!")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
