using ShoppingCart.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Business.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product FindBy(string articleId);
        int GetStockFor(string articleId);
        IEnumerable<Product> All();
        void DecreaseStockBy(string articleId, int amount);
        void IncreaseStockBy(string articleId, int amount);
    }
}
