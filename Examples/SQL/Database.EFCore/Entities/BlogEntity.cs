using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("blog")]
    public class BlogEntity
    {
        public int Id { get; set; }
        
        public CategoryEntity Category { get; set; }
        
        public DateTime TimeStamp { get; set; }
        
        public string Title { get; set; }
    }
}