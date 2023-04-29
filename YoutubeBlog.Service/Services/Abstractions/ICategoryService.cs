﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstractions
{
	public interface ICategoryService
	{
		Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
		Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24();
        Task<List<CategoryDto>> GetAllCategoriesDeleted();
        Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
		Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);

		Task<Category> GetCategoryByGuid(Guid id);
		Task<string> SafeDeleteCategoryAsync(Guid categoryId);
		Task<string> UndoDeleteCategoryAsync(Guid categoryId);


    }
}
