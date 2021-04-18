using ShoppingCart.Business.Constants;
using ShoppingCart.Business.Models;
using ShoppingCart.Business.Repositories.Interfaces;
using System;

namespace ShoppingCart.Business.Commands
{
    public class ChangeQuantityCommand : ICommand
    {
        IProductRepository _productRepository;
        IShoppingCartRepository _shoppingCartRepository;
        Product _product;
        Operation _operation;

        public ChangeQuantityCommand(IProductRepository productRepository,
                 IShoppingCartRepository shoppingCartRepository, Product product,Operation operation)
        {
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _product = product;
            _operation = operation;
        }
        public bool CanExecute()
        {
            if(_operation == Operation.Increase)
            {
                if (_productRepository.GetStockFor(_product.ArticleId) <= 0) return false; 
            }
            if (_operation == Operation.Decrease)
            {
                if (_shoppingCartRepository.Get(_product.ArticleId).Quantity <= 0) return false;
            }
            return true;
        }

        public void Execute()
        {
            if(_operation == Operation.Increase)
            {
                _shoppingCartRepository.IncreaseQuantity(_product.ArticleId);
                _productRepository.DecreaseStockBy(_product.ArticleId, 1);
            }
            if (_operation == Operation.Decrease)
            {
                _shoppingCartRepository.DecraseQuantity(_product.ArticleId);
                _productRepository.IncreaseStockBy(_product.ArticleId, 1);
            }
        }

        public void Undo()
        {
            if (_operation == Operation.Increase)
            {
                _shoppingCartRepository.DecraseQuantity(_product.ArticleId);
                _productRepository.IncreaseStockBy(_product.ArticleId, 1);
            }
            if (_operation == Operation.Decrease)
            {
                _shoppingCartRepository.IncreaseQuantity(_product.ArticleId);
                _productRepository.DecreaseStockBy(_product.ArticleId, 1);
            }
        }
    }
}
