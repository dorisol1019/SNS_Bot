using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweetBot.Models
{
    public class SerifData
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(10)]
        [Required]
        public string Name { get; set; }

        [MaxLength(140)]
        [Required]
        public string Text { get; set; }

        public DateTime? LastUsedTime { get; set; }
        
        public SerifType Type { get; set; }
    }

    public enum SerifType
    {
        Normal,
        Ganbare,
        Oyasumi
    }
}
