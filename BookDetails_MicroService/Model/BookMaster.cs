using System;
using System.ComponentModel.DataAnnotations;



namespace BookDetails_MicroService.Model
{
    public class BookMaster
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Book_Name { get; set; }

        [Required]
        public string Book_Author_Name { get; set; }

        [Required]
        [Range(1000000000000, 9999999999999, ErrorMessage = "ISBN should be of 13 digit")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ISBN_Num must have Length of 13")]
        public string ISBN_Num { get; set; }

        [Required]
        public DateTime Book_Publication_Date { get; set; }

    }
}
