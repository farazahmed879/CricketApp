using System.ComponentModel.DataAnnotations;

namespace CricketApplicationWebPortal.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}