using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
    }
}