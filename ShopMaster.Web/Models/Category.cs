using System.ComponentModel.DataAnnotations;

namespace ShopMaster.Web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public bool Status { get; set; }

    }
}
