using Dapper;
using WebApplication13.Domain.Bases;
using WebApplication13.Persistence.Infratructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication13.Persistence.Repositories.Base;
using Domain.Owner;

namespace WebApplication13.Persistence.Repositories
{
    public interface IOwnerRepository : IRepository<AddPost>
    {

    }
    public class OwnersRepository : IOwnerRepository
    {
        private readonly IUnitOfWork unitOfWork;
        
        public OwnersRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        private string AddSql = $@"insert into Post (Title,Description,ImageUrl)
                                                OUTPUT Inserted.Id 
                                    values(@{nameof(AddPost.Title)},
                                    @{nameof(AddPost.Description)},
                                    @{nameof(AddPost.ImageUrl)})";
        private string DeleteSql = $@"delete [User] where [User].Id=@id";


        private string UpdateSql = "";

        private string GetByIdSql = "select * from Post where Id=@id;";
        private const string GetAllSql = "select * from [Post]";
        public async Task<int> Add(AddPost entity)
        {
            try
            {
                var id = await unitOfWork.GetConnection().QuerySingleAsync<int>(AddSql, entity, unitOfWork.GetTransaction());
                return id;
                //return new Guid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(string id)
        {
            var param = new
            {
                id
            };
            try
            {
                await unitOfWork.GetConnection().QueryAsync(DeleteSql, param, unitOfWork.GetTransaction());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<AddPost>> Find(Expression<Func<AddPost, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AddPost>> GetAll()
        {
            try
            {
                var result = await unitOfWork.GetConnection().QueryAsync<AddPost>(GetAllSql, null, unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<ListResult<AddPost>> GetAllPaging(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<AddPost> GetById(string id)
        {
            var param = new
            {
                id
            };
            try
            {
                var result = await unitOfWork.GetConnection()
                    .QuerySingleAsync<AddPost>(GetByIdSql, param, unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Update(AddPost entity)
        {
            try
            {
                await unitOfWork.GetConnection().QueryAsync(UpdateSql, entity, unitOfWork.GetTransaction());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
