using eComShop.Domain.Dtos;
using eComShop.Domain.Entities;
using eComShop.Domain.ValueObjects;
namespace eComShop.Application.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto ToDto(Category category)
        {
            if (category == null)
                return null;

            return new CategoryDto
            {
                Id = category.Id.value,
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt,
                CreatedBy = category.CreatedBy,
                UpdatedBy = category.UpdatedBy
            };
        }

        public static Category ToEntity(CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return null;

            return new Category
            {
                Id = new CategoryId(categoryDto.Id),
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                CreatedAt = categoryDto.CreatedAt,
                UpdatedAt = categoryDto.UpdatedAt,
                CreatedBy = categoryDto.CreatedBy,
                UpdatedBy = categoryDto.UpdatedBy
            };
        }
    }
}