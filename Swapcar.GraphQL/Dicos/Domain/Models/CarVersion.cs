using Swapcar.GraphQL.Dicos.EntityFramework.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swapcar.GraphQL.Dicos.Domain.Models
{
    [Table(DbConsts.TBL_BRAND_VERSION, Schema = DbConsts.SCH_BRAND)]
    public class CarVersion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("version_id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("model_id")]
        public int CarModelId { get; set; }

        [ForeignKey("CarModelId")]
        public virtual CarModel CarModel { get; set; }
    }
}
