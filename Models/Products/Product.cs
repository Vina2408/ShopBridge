using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Models.Products
{
    [ExcludeFromCodeCoverage]
    public class Product : IProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
    
    public interface IProduct
    {
        string Name { get; set; }
        string Description { get; set; }
        decimal? Price { get; set; }
        public bool IsActive { get; set; }  
    }
    [ExcludeFromCodeCoverage]
    public class AddProductModel : IProduct
    {
        [StringLength(maximumLength:50,ErrorMessage ="Name length should not exceed 50 charecters")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [StringLength(maximumLength: 200, ErrorMessage = "Description length should not exceed 200 charecters")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set ; }
        [Range(minimum:0,maximum:1500)]
        [Required(ErrorMessage = "Price is required")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; } = true;
    }
    [ExcludeFromCodeCoverage]
    public class UpdateProductModel : IProduct
    {
        [Range(minimum:0,maximum:Int32.MaxValue)]
        [Required(ErrorMessage = "Id is required")]
        public int? Id { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Name length should not exceed 50 charecters")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [StringLength(maximumLength: 200, ErrorMessage = "Description length should not exceed 200 charecters")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Range(minimum: 0, maximum: 1500)]
        [Required(ErrorMessage = "Price is required")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; } = true;
    }
}
