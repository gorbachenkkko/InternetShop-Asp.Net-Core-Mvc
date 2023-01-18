using InternetShop.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace InternetShop.Domain.ViewModels.Clothes
{
    public class ClothesViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название товара")]
        [MaxLength(20, ErrorMessage = "Название должно иметь длину меньше 20 символов")]
        [MinLength(3, ErrorMessage = "Название должно иметь длину больше 3 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Выберите пол")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Выберите тип одежды")]
        public СlothingType СlothingType { get; set; }

        [Required(ErrorMessage = "Выберите цвет одежды")]
        public Color Color { get; set; }

        [Required(ErrorMessage = "Выберите размер одежды")]
        public Size Size { get; set; }

        [Required(ErrorMessage ="Введите описание товара")]
        [MaxLength(20, ErrorMessage = "Описание должно иметь длину меньше 200 символов")]
        [MinLength(3, ErrorMessage = "Описание должно иметь длину больше 10 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Ввелите ссылку на фото товара")]
        public string ImageUrl { get; set; }
    }
}
