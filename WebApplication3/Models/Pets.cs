using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Pets
    {
        [Key]
        public long PetsId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}