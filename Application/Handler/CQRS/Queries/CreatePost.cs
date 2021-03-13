using Application.Handler.Base;
using Application.Services;
using Application.Validators;
using AutoMapper;
using Domain.Owner;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication13.Persistence.CustomException;
using WebApplication13.Persistence.Infratructure;

namespace Application.Handler.CQRS.Queries
{

    public class CreatePost
    {
        public class CreatePostRequest : BaseRequest, IRequestWrapper<AddPost>
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
        }

        public class CreatePostHandler : IHandlerWrapper<CreatePostRequest, AddPost>
        {
            private readonly IMapper mapper;
            private readonly IOwnerService addressService;
            private readonly IUnitOfWork unitOfWork;

            public CreatePostHandler(IMapper mapper, IOwnerService AddressService, IUnitOfWork unitOfWork)
            {
                this.mapper = mapper;
                this.addressService = AddressService;
                this.unitOfWork = unitOfWork;
            }
            public async Task<BaseResponses<AddPost>> Handle(CreatePostRequest request, CancellationToken cancellationToken)
            {
                BaseResponses<AddPost> responses = null;
                using (var trx = unitOfWork.BeginTransaction())
                {
                    try
                    {
                        var mapData = mapper.Map<AddPost>(request);
                        var data = await addressService.Add(mapData);
                        responses = new BaseResponses<AddPost>(data);
                        unitOfWork.SaveChanges();
                    }
                    catch (RestException ex)
                    {
                        trx.Rollback();
                        responses = new BaseResponses<AddPost>(ex.StatusCode, ex.Message);
                    }
                    return responses;
                }
            }
        }
    }
}
