
using Business.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class ProductService
    {

        private readonly IProductDao _productDao;
        public ProductService(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public async Task<int> CreateProduct(ProductViewModel productViewModel)
        {
            Product product = new()
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Picture = productViewModel.Picture,
                Code = productViewModel.Code
            };

            return await _productDao.AddAsync(product);

        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await _productDao.GetAsync(id);
            return await _productDao.RemoveAsync(product);
        }

        public async Task<int> EditProduct(int id, ProductViewModel productViewModel)
        {
            var product = await _productDao.GetAsync(id);
            product.Name = productViewModel.Name;
            product.Price = productViewModel.Price;
            product.Picture = productViewModel.Picture;
            product.Code = productViewModel.Code;
            return await _productDao.UpdateAsync(product);
        }

        public async Task<ProductViewModel> GetProductDetail(int id)
        {
            var product = await _productDao.GetAsync(id);
            ProductViewModel productViewModel = new ProductViewModel();
            
            if (product != null)
            {
                productViewModel.Id = product.Id;
                productViewModel.Name = product.Name;
                productViewModel.CreationDate = product.CreationDate;
                productViewModel.Price = product.Price;
                productViewModel.Picture = product.Picture;
                productViewModel.Code = product.Code;
            }

            return productViewModel;
        }

        public async Task<List<ProductViewModel>> GetProducts()
        {
            var products = await _productDao.GetAsync();
            List<ProductViewModel> productViewModel = products.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                Price = x.Price,
                Picture = x.Picture,
                Code = x.Code
            }).ToList();

            return productViewModel;
        }
    }
}
