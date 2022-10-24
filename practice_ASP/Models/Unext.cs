using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace practice_ASP.Models
{
    public partial class Unext
    {
        public int Id { get; set; }
        [Display(Name="タイトル")]
        public string Name { get; set; } = null!;
        [Display(Name = "動画時間")]
        public int Length { get; set; }
        [Display(Name = "ジャンル")]
        public string Genre { get; set; } = null!;
    }
}
