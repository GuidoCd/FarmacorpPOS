using System.Collections.Generic;

namespace FarmacorpPOS.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}
