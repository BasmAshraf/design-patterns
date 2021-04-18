using ShoppingCart.Business.Models;
using ShoppingCart.Business.Repositories.Interfaces;

namespace ShoppingCart.Business.Commands
{
    public class AddToCartCommand : ICommand
    {
        IProductRepository _productRepository;
        IShoppingCartRepository _shoppingCartRepository;
        Product _product;

        public AddToCartCommand(IProductRepository productRepository,
                 IShoppingCartRepository shoppingCartRepository, Product product)
        {
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _product = product;
        }

        public bool CanExecute()
        {
            if (_product == null) return false;
            if (_productRepository.GetStockFor(_product.ArticleId) <= 0) return false;
            return true;
        }

        public void Execute()
        {
            if (_product != null)
            {
                _shoppingCartRepository.Add(_product);
                _productRepository.DecreaseStockBy(_product.ArticleId, 1);
            }
        }

        public void Undo()
        {
            if (_product != null)
            {
                _shoppingCartRepository.RemoveAll(_product.ArticleId);
                _productRepository.IncreaseStockBy(_product.ArticleId, _shoppingCartRepository.Get(_product.ArticleId).Quantity);
            }
        }
    }
}
