using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8 {
    [Table("Categories")]
    public class Category {
        public Category() {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
