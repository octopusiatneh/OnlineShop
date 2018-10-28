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
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }
    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private ISlideRepository _slideRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork,ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x=>x.ID==CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status == true);
        }
    }
}
