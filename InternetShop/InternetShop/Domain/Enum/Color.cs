using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace InternetShop.Domain.Enum
{
    public enum Color
    {
        [Display(Name ="Красный")]
        Red,
        [Display(Name = "Зелёный")]
        Green,
        [Display(Name = "Синий")]
        Blue,
        [Display(Name = "Жёлтый")]
        Yellow,
        [Display(Name = "Белый")]
        White,
        [Display(Name = "Чёрный")]
        Black,
        [Display(Name = "Оранжевый")]
        Orange,
        [Display(Name = "Фиолетовый")]
        Purple
    }
}
