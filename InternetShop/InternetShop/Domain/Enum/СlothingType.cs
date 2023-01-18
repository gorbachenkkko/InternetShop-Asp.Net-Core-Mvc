using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Domain.Enum
{
    public enum СlothingType
    {
        [Display(Name ="Головной убор")]
        Headdress,
        [Display(Name = "Футболка")]
        T_shirt,
        [Display(Name = "Куртка")]
        Jacket,
        [Display(Name = "Худи")]
        Hoodie,
        [Display(Name = "Шорты")]
        Shorts,
        [Display(Name = "Штаны")]
        Pants,
    }
}
