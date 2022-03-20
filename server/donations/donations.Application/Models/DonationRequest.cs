using donations.DM.Models;
using System.ComponentModel.DataAnnotations;

namespace donations.Application.Models
{
    public class DonationRequest
    {
        const string alphaRegex = @"^[a-zA-Zא-ת ]+$";

        [Required]
        public float Amount { get; set; }
        [Required]
        [RegularExpression(alphaRegex, ErrorMessage = "EntityName wrong validation, Use letters only please")]
        public string EntityName { get; set; }
        [Required]
        [EnumDataType(typeof(Entity))]
        public string EntityType { get; set; }
        [Required]
        [RegularExpression(alphaRegex, ErrorMessage = "Destiny wrong validation, Use letters only please")]
        public string Destiny { get; set; }
        [RegularExpression(alphaRegex, ErrorMessage = "Condition wrong validation, Use letters only please")]
        public string Conditions { get; set; }
        [Required]
        [EnumDataType(typeof(Coin))]
        public string Coin { get; set; }
        [Required]
        public float ExchangeRate { get; set; }
    }
}
