using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Domain.Enum
{
    public enum Gender
    {
        [Display(Name ="Мужской")]
        Man,
        [Display(Name = "Женский")]
        Woman
    }
}
