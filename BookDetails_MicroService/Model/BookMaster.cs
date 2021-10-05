using System;
using System.ComponentModel.DataAnnotations;



namespace BookDetails_MicroService.Model
{
    public class BookMaster
    {
        [Key]
        [Required]
        public Decimal Id { get; set; }
        [Required]
        public string Book_Name { get; set; }
        [Required]
        public string Book_Author_Name { get; set; }
        [Required]
        public string ISBN_Num { get; set; }
        [Required]
        public DateTime Book_Publication_Date { get; set; }

        public BookMaster FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
