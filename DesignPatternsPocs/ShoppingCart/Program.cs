using ShoppingCart.Business.Commands;
using ShoppingCart.Business.Constants;
using ShoppingCart.Business.Repositories;
using System;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var shoppingCartRepository = new ShoppingCartRepository();
            var productsRepository = new ProductsRepository();

            var product = productsRepository.FindBy("SM7B");

            var addToCartCommand = new AddToCartCommand(
                productsRepository,
                shoppingCartRepository,
                product);

            var increaseQuantityCommand = new ChangeQuantityCommand(
                productsRepository,
                shoppingCartRepository,
                product,
                Operation.Increase);

            var manager = new CommandManager();
            manager.Invoke(addToCartCommand);
            manager.Invoke(increaseQuantityCommand);
            manager.Invoke(increaseQuantityCommand);
            manager.Invoke(increaseQuantityCommand);
            manager.Invoke(increaseQuantityCommand);

            PrintCart(shoppingCartRepository);

            manager.Undo();

            PrintCart(shoppingCartRepository);
        }

        static void PrintCart(ShoppingCartRepository shoppingCartRepository)
        {
            var totalPrice = 0m;
            foreach (var lineItem in shoppingCartRepository.LineItems)
            {
                var price = lineItem.Value.Product.Price * lineItem.Value.Quantity;

                Console.WriteLine($"{lineItem.Key} " +
                    $"${lineItem.Value.Product.Price} x {lineItem.Value.Quantity} = ${price}");

                totalPrice += price;
            }

            Console.WriteLine($"Total price:\t${totalPrice}");
        }
    }
}
