using Application.DataTransferObject;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;

        }

        public async Task<bool> saveCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.Code = Guid.NewGuid().ToString();
            var result = await _categoryWriteRepository.AddAsync(category);
            if (!result)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public async Task<Category> getCategoryById(int id)
        {
            var category = await _categoryReadRepository.GetWhereWithInclude(x => x.Id == id, true, x => x.SubCategories, x => x.ParentCategory).FirstOrDefaultAsync();
            return category;
        }

        public async Task<List<Category>> categoryList()
        {
            List<Category> categories = await _categoryReadRepository.GetAllWithInclude(true, x => x.SubCategories, x => x.ParentCategory).ToListAsync();
            return categories;
        }
    }
}
