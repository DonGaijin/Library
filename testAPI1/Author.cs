using System.ComponentModel.DataAnnotations.Schema;

namespace testAPI1
{
    public class Author
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "Datetime2")]
        public DateTime BirthDate { get; set; }
        [Column(TypeName = "bit")]
        public Boolean Gender { get; set; }
        
    }
}