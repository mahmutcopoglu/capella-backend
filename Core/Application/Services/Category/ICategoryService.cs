using Application.DataTransferObject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICategoryService
    {
        Task<bool> saveCategory(CategoryDto categoryDto);
        Task<List<Category>> categoryList();
        Task<Category> getCategoryById(int id);
    }
}
