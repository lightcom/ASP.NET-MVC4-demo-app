using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuestBookZhKassenov.Models
{
    public class FeedbackViewModel
    {
        [Required(ErrorMessage="Укажите имя пользователя")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Укажите электронную почту")]
        public string Email { get; set; }
        public string Homepage { get; set; }
        [Required(ErrorMessage = "Оставьте запись")]
        public string Text { get; set; }
    }
}