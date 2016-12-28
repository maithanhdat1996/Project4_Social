using SocialFashion.Data.Infrastructure;
using SocialFashion.Data.Repositories;
using SocialFashion.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialFashion.Service
{
    public interface IAspNetUserService
    {
        IEnumerable<AspNetUser> GetListAspNetUserByIdPaging(int page, int pageSize, string sort, out int totalRow);
        IEnumerable<AspNetUser> GetAllMembersByKeywords(string keywords, int page, int pageSize, string sort, out int totalRow);

        void SaveChanges();
    }
    public class AspNetUserService : IAspNetUserService
    {
        IAspNetUserRepository _aspNetUserRepository;
        IUnitOfWork _unitOfWork;

        public AspNetUserService(IAspNetUserRepository aspNetUserRepository, IUnitOfWork unitOfWork)
        {
            this._aspNetUserRepository = aspNetUserRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<AspNetUser> GetListAspNetUserByIdPaging(int page, int pageSize, string sort, out int totalRow)
        {
            var query = _aspNetUserRepository.GetMulti(x => x.EmailConfirmed);

            switch (sort)
            {
                //case "popular":
                //    query = query.OrderByDescending(x => x.ViewCount);
                //    break;
                //case "discount":
                //    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                //    break;
                //case "price":
                //    query = query.OrderBy(x => x.Price);
                //    break;
                default:
                    query = query.OrderByDescending(x => x.Name);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<AspNetUser> GetAllMembersByKeywords(string keywords, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _aspNetUserRepository.GetMulti(x => x.Name.Contains(keywords)   || x.UserName.Contains(keywords));

            switch (sort)
            {
                //case "popular":
                //    query = query.OrderByDescending(x => x.ViewCount);
                //    break;
                //case "discount":
                //    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                //    break;
                //case "price":
                //    query = query.OrderBy(x => x.Price);
                //    break;
                default:
                    query = query.OrderByDescending(x => x.Name);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
