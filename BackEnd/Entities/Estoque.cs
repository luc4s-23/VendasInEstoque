using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackEnd.Entities{
    public class Estoque
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Item")]
        public int Id_item_FK { get; set; }
        public int QntAtual { get; set; }

    }
}