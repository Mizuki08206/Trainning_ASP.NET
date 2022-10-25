using System.ComponentModel;//は[Display(Name="表示名")]
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotationsは、[DisplayName("表示名")]

namespace practice_ASP.Models
{
	public class Entry
	{
		[DisplayName("名前")]
        public string Name { get; set; }
        [DisplayName("年齢")]
        [RegularExpression(@"^\w{3}", ErrorMessage = "123の形で入力")]
        public int Age { get; set; }
        [DisplayName("好きなアニメ")]
        public string Anime { get; set; }
	}
}
