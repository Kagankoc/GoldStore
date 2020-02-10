using GoldStore.Models.Shared;
using System.Collections.Generic;

namespace GoldStore.Models.Cart
{
    public class Cart : BaseObject
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }


        public string UniqueCartId { get; set; }
        public CartStatus CartStatus { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
