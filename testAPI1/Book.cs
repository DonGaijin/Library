using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace testAPI1
{
    public class Book
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        public string Title { get; set; }
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Description { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Rating { get; set; }
        [Column(TypeName = "NVARCHAR(13)")]
        public string ISBN { get; set; }
        [Column(TypeName = "Datetime2")]
        public DateTime PublicationDate { get; set; }
    }
}
