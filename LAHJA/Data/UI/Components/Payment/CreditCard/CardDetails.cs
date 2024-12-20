using System.ComponentModel.DataAnnotations;

namespace LAHJA.Data.UI.Components.Payment.CreditCard
{




    public class CardDetails
    {
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        public string Cvc{ get; set; }
        
        public string CardType { get; set; }
        
        public bool IsSelected { get; set; }
    }




}


