using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BuklyWebRazor_Temp.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    [DisplayName("Category Name")]
    public string Name { get; set; }
    [DisplayName("Category Description")]
    [Range(1,100, ErrorMessage = "Display Value must be between 1 and 100")]
    public int DisplayOrder { get; set; }
}