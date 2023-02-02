using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspMvcQuestRoom.Models
{
    public class QuestRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Difficult { get; set; }
        public string Users { get; set; }
        public string Fear { get; set; }
    }
}
