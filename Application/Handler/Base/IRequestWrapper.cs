using Application.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handler.Base
{
    public interface IRequestWrapper<T> : IRequest<BaseResponses<T>>
    {
    }
    public interface IHandlerWrapper<Tin, Tout> : IRequestHandler<Tin, BaseResponses<Tout>>
        where Tin : IRequestWrapper<Tout>
    {
    }
}
