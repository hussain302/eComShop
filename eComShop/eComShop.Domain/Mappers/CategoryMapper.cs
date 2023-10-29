using eComShop.Domain.Dtos;
using eComShop.Domain.Entities;
using eComShop.Domain.ValueObjects;
namespace eComShop.Application.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto ToDto(Category category) 
            => new CategoryDto
        {
            Id = category.Id.value,
            Name = category.Name,
            Description =  !string.IsNullOrEmpty(category.Description)? category.Description : string.Empty,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt,
            CreatedBy = category.CreatedBy,
            UpdatedBy = category.UpdatedBy
        };

        public static Category ToEntity(CategoryDto categoryDto) 
            => new Category
        {
            Id = new CategoryId(categoryDto.Id),
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            CreatedAt = categoryDto.CreatedAt,
            UpdatedAt = categoryDto.UpdatedAt,
            CreatedBy = categoryDto.CreatedBy,
            UpdatedBy = categoryDto.UpdatedBy
        };

        public static List<CategoryDto> ToDtoList(IEnumerable<Category> categories) => categories.Select(ToDto).ToList();


    }
}