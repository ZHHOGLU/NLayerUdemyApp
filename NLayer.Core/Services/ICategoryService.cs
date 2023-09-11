using NLayer.Core.DTO_s;
using NLayer.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {

        public Task<CustomResponseDTO<CategoryWithProductsDTO>> GetSingleCategoryByIdWithProductAsync(int categoryId);
    }
}
