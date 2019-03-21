using Swapcar.GraphQL.Users.EntityFramework.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swapcar.GraphQL.Users.Domain.Models
{
    [Table(DbConsts.TBL_AUTH_USER, Schema = DbConsts.SCH_AUTH)]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("nickname")]
        public string NickName { get; set; }

        [Column("hash_password")]
        public string HashPassword { get; set; }

        [Column("salt")]
        public string Salt { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
