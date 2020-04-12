using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork.Service.Dto
{
    public class UserDto : BaseDto
    {
        public UserDto()
        {
            this.TaskHistory = new List<TaskHistoryDto>();
        }

        [Required(ErrorMessage = "Kullanıcı tipi boş geçilemez!")]
        [Range(minimum: 1, maximum: Int32.MaxValue, ErrorMessage = "Kullanıcı tipi boş geçilemez!")]
        public Nullable<int> UserTypeId { get; set; }
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual List<TaskHistoryDto> TaskHistory { get; set; }
        public virtual UserTypeDto UserType { get; set; }

        public List<UserTypeDto> UserTypes { get; set; }
    }
}
