using GoldStore.Models.Addresses;
using GoldStore.Models.Customers;
using GoldStore.Models.Orders;
using GoldStore.Models.Shared;
using GoldStore.Repository.Interfaces;
using GoldStore.Services.Interfaces;
using GoldStore.ViewModels.Checkout;

namespace GoldStore.Services.Classes
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartService _cartService;

        public CheckoutService(ICustomerRepository customerRepository,
            IPersonRepository personRepository,
            IAddressRepository addressRepository,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository,
            ICartService cartService)
        {
            _customerRepository = customerRepository;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
        }

        public void ProcessCheckout(CheckoutViewModel checkoutViewModel)
        {
            var person = new Person
            {
                FirstName = checkoutViewModel.FirstName,
                MiddleName = checkoutViewModel.MiddleName,
                LastName = checkoutViewModel.LastName,
                EmailAddress = checkoutViewModel.EmailAddress,
                IsDeleted = false

            };
            _personRepository.SavePerson(person);
            var address = new Address
            {
                AddressLine1 = checkoutViewModel.AddressLine1,
                AddressLine2 = checkoutViewModel.AddressLine2,
                City = checkoutViewModel.City,
                State = checkoutViewModel.State,
                Country = checkoutViewModel.Country,
                IsDeleted = false
            };
            _addressRepository.SaveAddress(address);

            var customer = new Customer
            {
                PersonId = person.Id,
                Person = person,
                IsDeleted = false
            };

            _customerRepository.SaveCustomer(customer);

            var cart = _cartService.GetCart();

            if (cart != null)
            {
                var cartItems = _cartItemRepository.FindCartItemsByCartId(cart.Id);
                var cartTotal = _cartService.GetCartTotal();
                double shipplingCharge = 0;
                var orderTotal = cartTotal + shipplingCharge;

                var order = new Order
                {
                    OrderTotal = orderTotal,
                    OrderItemTotal = cartTotal,
                    ShippingCharge = shipplingCharge,
                    AddressId = address.Id,
                    DeliveryAddress = address,
                    CustomerId = customer.Id,
                    Customer = customer,
                    OrderStatus = OrderStatus.Submitted
                };
                _orderRepository.SaveOrder(order);

                foreach (var cartItem in cartItems)
                {
                    var orderItem = new OrderItem
                    {
                        Quantity = cartItem.Quantity,
                        Order = order,
                        OrderId = order.Id,
                        Product = cartItem.Product,
                        ProductId = cartItem.ProductId
                    };
                    _orderItemRepository.SaveOrderItem(orderItem);
                }
                _cartRepository.DeleteCart(cart);
            }
        }
    }
}
