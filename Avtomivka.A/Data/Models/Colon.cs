namespace Avtomivka.A.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Colon", Schema = "17118057")]
    public class Colon : BaseModel
    {
        public int Number { get; set; }

        public bool Taken { get; set; } = false;

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
