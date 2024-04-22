using System.ComponentModel.DataAnnotations;

namespace MinhasTarefas.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
