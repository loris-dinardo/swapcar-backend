using Swapcar.GraphQL.Dicos.EntityFramework.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swapcar.GraphQL.Dicos.Domain.Models
{
    [Table(DbConsts.TBL_BRAND_MODEL, Schema = DbConsts.SCH_BRAND)]
    public class CarModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("model_id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public virtual IEnumerable<CarVersion> Versions { get; set; }
        
        [Column("brand_id")]
        public int CarBrandId { get; set; }

        [ForeignKey("CarBrandId")]
        public virtual CarBrand CarBrand { get; set; }
    }
}
