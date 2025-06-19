using System.ComponentModel.DataAnnotations;

namespace StudentManagementMVC.Models
{
    public class Student
    {
        public int Id { get; set; }//Benzersiz(uniq) bir kimlik oluşturur.
        //public string? Name { get; set; }Eğer null yani boş geçilebilir olsun istiyorsak soru(?) işareti koymamız yeterli olacaktır.
        [Required]//Name alanı zorunludur. Kullanıcı burayı boş geçemez
        public string StudentName { get; set; }
        [Range(18,45)]
        public int Age { get; set; }
        //[Required]
        public string? Department { get; set; }
    }
}
