using OnlineShop.Common;
using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repositories;
using OnlineShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service
{
    public interface IProductService
    {
        Product Add(Product Product);

        void Update(Product Product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetSortedProduct(string sort);

        IEnumerable<Product> Search(string keyword);

        IEnumerable<Product> GetAll(string keyword);

        IEnumerable<Product> GetSaleProducts(int maxProduct);

        IEnumerable<Product> GetHotProducts(int maxProduct);

        IEnumerable<Product> GetLastestProducts(int maxProduct);

        IEnumerable<string> GetProductByName(string keyword);

        Product GetById(int id);

        void Save();
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;

        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IProductTagRepository productTagRepository,
            ITagRepository _tagRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._productTagRepository = productTagRepository;
            this._tagRepository = _tagRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product Product)
        {
            var product = _productRepository.Add(Product);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] tags = Product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
            }
            return product;
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public IEnumerable<Product> GetHotProducts(int maxProduct)
        {
            return _productRepository.GetMulti(x => x.Status && x.HotFlag == true).OrderByDescending(x => x.CreatedDate).Take(maxProduct);

        }

        public IEnumerable<Product> GetLastestProducts(int maxProduct)
        {
            return _productRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(maxProduct);
        }

        public IEnumerable<string> GetProductByName(string keyword)
        {
            return _productRepository.GetMulti(x => x.Status && x.Name.Contains(keyword)).Select(x=>x.Name);
        }

        public IEnumerable<Product> GetSaleProducts(int maxProduct)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetSortedProduct(string sort)
        {
            var query = _productRepository.GetMulti(x => x.Status);
            switch (sort)
            {
                case "moi-nhat":
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
                case "khuyen-mai":
                    query = _productRepository.GetMulti(x => x.PromotionPrice.HasValue);
                    break;
                case "gia-thap-den-cao":
                    query = query.OrderBy(x => x.Price);
                    break;
                case "price-0-50":
                    query = _productRepository.GetMulti(x => x.Price >= 0 && x.Price < 50);
                    break;
                case "price-50-100":
                    query = _productRepository.GetMulti(x => x.Price >= 50 && x.Price < 100);
                    break;
                case "price-100-150":
                    query = _productRepository.GetMulti(x => x.Price >= 100 && x.Price < 150);
                    break;
                case "price-150-200":
                    query = _productRepository.GetMulti(x => x.Price >= 150 && x.Price < 200);
                    break;
                case "price-200":
                    query = _productRepository.GetMulti(x => x.Price >= 200);
                    break;
                default:
                    break;
            }
            return query;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Product> Search(string keyword)
        {
            var query = _productRepository.GetMulti(x => x.Status && x.Name.Contains(keyword));
            switch (keyword)
            {
                case "moi-nhat":
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
                case "khuyen-mai":
                    query = _productRepository.GetMulti(x => x.PromotionPrice.HasValue);
                    break;
                case "gia-thap-den-cao":
                    query = query.OrderBy(x => x.Price);
                    break;
                case "price-0-50":
                    query = _productRepository.GetMulti(x => x.Price >= 0 && x.Price < 50);
                    break;
                case "price-50-100":
                    query = _productRepository.GetMulti(x => x.Price >= 50 && x.Price < 100);
                    break;
                case "price-100-150":
                    query = _productRepository.GetMulti(x => x.Price >= 100 && x.Price < 150);
                    break;
                case "price-150-200":
                    query = _productRepository.GetMulti(x => x.Price >= 150 && x.Price < 200);
                    break;
                case "price-200":
                    query = _productRepository.GetMulti(x => x.Price >= 200);
                    break;
                default:
                    break;
            }
            return query;
        }

        public void Update(Product Product)
        {
            _productRepository.Update(Product);
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] tags = Product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.DeleteMulti(x => x.ProductID == Product.ID);
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }

            }
        }
    }
}
