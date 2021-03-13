using Application.Services.Bases;
using Domain.Owner;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication13.Domain.Bases;
using WebApplication13.Persistence.CustomException;
using WebApplication13.Persistence.Infratructure;
using WebApplication13.Persistence.Repositories;

namespace Application.Services
{
    public interface IOwnerService : IBaseServices<AddPost>
    {
        
    }
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public OwnerService(IOwnerRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<AddPost> Add(AddPost entity)
        {

            try
            {
                var addedId = await productRepository.Add(entity);

                var result = await productRepository.GetById(addedId.ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, ex.Message);
            }

        }

        public async Task<string> Delete(string id)
        {

            try
            {
                await productRepository.Delete(id);
                return "OK";
            }
            catch (Exception ex)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, ex.Message);
            }

        }

        public async Task<IEnumerable<AddPost>> Find(Expression<Func<AddPost, bool>> predicate)
        {

            try
            {
                var result = await productRepository.Find(predicate);
                return result;
            }
            catch (Exception ex)
            {

                throw new RestException(System.Net.HttpStatusCode.NotFound, ex.Message);
            }

        }

        public async Task<IEnumerable<AddPost>> GetAll()
        {

            try
            {
                var result = await productRepository.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, ex.Message);
            }

        }

        public Task<ListResult<AddPost>> GetAllPaging(int offset, int limit)
        {

            //try
            //{
            //    var result = await productRepository.GetAllPaging(offset, limit);
            //    return result;
            //}
            //catch (Exception ex)
            //{

            throw new Exception();
            //}

        }

        public async Task<AddPost> GetById(string id)
        {

            try
            {
                var result = await productRepository.GetById(id);
                return result;
            }
            catch (Exception ex)
            {

                throw new RestException(System.Net.HttpStatusCode.NotFound, ex.Message);
            }

        }

        public Task<AddPost> Update(AddPost entity)
        {
            return Task.FromResult(entity);
            //try
            //{
            //    if (entity.Password == string.Empty)
            //        throw new Exception("Id can not be null");

            //    await productRepository.Update(entity);
            //    var product = await productRepository.GetById(entity.Id.ToString());
            //    return product;
            //}
            //catch (Exception ex)
            //{
            //    throw new RestException(System.Net.HttpStatusCode.NotFound, ex.Message);
            //}

        }
    }
}
