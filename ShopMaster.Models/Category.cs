using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ShopMaster.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        [DisplayName("Category Name")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }
        public bool Status { get; set; } = true;

    }
}
