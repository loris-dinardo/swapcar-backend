using Swapcar.GraphQL.Dicos.EntityFramework.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swapcar.GraphQL.Dicos.Domain.Models
{
    [Table(DbConsts.TBL_BRAND_BRAND, Schema = DbConsts.SCH_BRAND)]
    public class CarBrand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("brand_id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public virtual IEnumerable<CarModel> Models { get; set; }
    }
}
