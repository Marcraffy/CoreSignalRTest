using System.ComponentModel.DataAnnotations;

namespace CoreSignalRTest.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}