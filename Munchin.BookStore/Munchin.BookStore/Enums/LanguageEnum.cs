using System.ComponentModel.DataAnnotations;

namespace Munchin.BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display( Name = "Pigin Language" )]
        Pigin = 10,

        [Display( Name = "Ibibio Language" )]
        Ibibio = 11,

        [Display( Name = "Yoruba Language" )]
        Yoruba = 12,

        [Display( Name = "Igbo Language" )]
        Igbo = 13,

        [Display( Name = "Hausa Language" )]
        Hausa = 14

    }
}
