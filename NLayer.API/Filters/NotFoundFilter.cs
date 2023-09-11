using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTO_s;
using NLayer.Core.Model;
using NLayer.Core.Services;
using NLayer.Service.Exceptions;

namespace NLayer.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _services;

        public NotFoundFilter(IService<T> services)
        {
            _services = services;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null) 
            {
                await next.Invoke();
                return;
            }
            var id = (int)idValue;
            var anyEntity = await _services.AnyAsync(x=>x.Id==id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponseDTO<NoContentDTO>.Fail(404, $"{typeof(T).Name}({id}) not found"));
            
        }
    }
}
