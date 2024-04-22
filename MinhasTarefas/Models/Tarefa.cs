using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MinhasTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
        public string Status { get; set; }
        public int CreationUserId { get; set; }
        public DateTime LastUpdateDate { get; set; } = DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
    }
}
