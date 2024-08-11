using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BlogApplicationAPI.Models
{
    public class Blog
    {
        public ObjectId Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(150)]
        public string Summary { get; set; }
        [Required]
        [StringLength(5000)]
        public string BlogPost { get; set; }
    }
}
