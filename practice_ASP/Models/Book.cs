using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace practice_ASP.Models
{
    /// <summary>
    /// 書籍
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        [Display(Name ="書籍")]
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int publisherId { get; set; }
        [Display(Name ="価格")]
        public int Price { get; set; }

        public virtual Author Author { get; set; }
        public virtual publisher Publisher { get; set; }

        [Display(Name ="発売日")]
        [DataType(DataType.Date)]
        public DateTime? PublishDate { get; set; }
        [Display(Name ="ISBNコード")]
        [RegularExpression("[0-9{3}-[0-9]{1}-[0-9]{3,5}-[0-9]{3,5}-0-9A-Z]{1}")]
        public string ISBN { get; set; }
    }
    /// <summary>
    /// 出版社
    /// </summary>
    public class Publisher
    {
        public int Id { get;set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Book { get; set; }
    }
    /// <summary>
    /// 著者名
    /// </summary>
    public partial class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PerfectureId { get; set; }

        public virtual ICollection<Book> Book { get; set; }
        public virtual Perfecture Perfecture { get; set; }
    }

    public partial class Perfecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //初回のみ都道府県のデータを作る
        public static void Initialize(DbContext context)
        {
            var t = context.Set<Perfecture>();
            if (t.Any() == false)
            {
                //データを作る
                t.AddRange(
                    new Perfecture() { Name = "北海道" },
                    new Perfecture() { Name = "青森県" },
                    new Perfecture() { Name = "東京都" },
                    new Perfecture() { Name = "千葉県" },
                    new Perfecture() { Name = "茨城県" },
                    new Perfecture() { Name = "埼玉県" },
                    new Perfecture() { Name = "群馬県" },
                    new Perfecture() { Name = "山梨県" },
                    new Perfecture() { Name = "長野県" },
                    new Perfecture() { Name = "福岡県" },
                    new Perfecture() { Name = "沖縄県" },
                    new Perfecture() { Name = "鹿児島県" });
                context.SaveChanges();
            }
        }
    }
}
