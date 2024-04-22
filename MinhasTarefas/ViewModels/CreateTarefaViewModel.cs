using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MinhasTarefas.ViewModels
{
    public class CreateTarefaViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }        
        [Required]
        public string Status { get; set; }
        
    }

    public class UpdateTarefaViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

}
