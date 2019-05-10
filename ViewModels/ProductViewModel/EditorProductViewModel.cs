using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;

namespace ProductCatalog.ViewModels.ProductViewModel
{
    public class EditorPRoductViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }

        public void Validate()
        {            
            AddNotifications(
                new Contract()
                .HasMaxLen(Title, 120, "Title", "O títule deve conter até 120 caracteres")
                .HasMinLen(Title, 3, "Title", "O títule deve conter pelo menos 3 caracteres")
                .IsGreaterThan(Price, 0, "Price", "O preço deve ser maior que zero")
            );
        }
    }
}