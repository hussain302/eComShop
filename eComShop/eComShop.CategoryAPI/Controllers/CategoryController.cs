using eComShop.Application.Mappers;
using eComShop.Domain.Dtos;
using eComShop.Infrastructure.DataAccess.UnitOfWork;
using eComShop.Infrastructure.Security.ApiFilters;
using eComShop.Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace eComShop.CategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateApi]
    [ApiVersion("1.0")]
    public class CategoryController : BaseApiController
    {

        public CategoryController(IHttpContextAccessor httpContextAccessor, ILogger<CategoryController> logger,
            IUnitOfWork unitOfWork) : base(httpContextAccessor, logger, unitOfWork) { }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _unitOfWork.Category.GetAllAsync();

                return Ok(new Result<IEnumerable<CategoryDto>>
                {
                    Success = true,
                    Message = "Categories retrieved successfully.",
                    Data = CategoryMapper.ToDtoList(categories),
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Result<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid categoryId)
        {
            try
            {
                var category = await _unitOfWork.Category.GetByIdAsync(id:categoryId);
                if (category == null)
                {
                    return NotFound(new Result<object>
                    {
                        Success = false,
                        Message = "Category not found."
                    });
                }

                return StatusCode((int)HttpStatusCode.OK, new Result<CategoryDto>
                {
                    Success = true,
                    Message = "Category retrieved successfully.",
                    Data = CategoryMapper.ToDto(category),
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Result<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null,
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto category)
        {
            try
            {
                await _unitOfWork.Category.AddAsync(CategoryMapper.ToEntity(category));
                int saveResponse = await _unitOfWork.SaveAsync();
                var message = saveResponse > 0 ? $"Category '{category.Name}' has been added successfully."
                                               : $"Failed to add the category '{category.Name}'.";
                return Ok(new Result<object>
                {
                    Success = true,
                    Message = message,
                    Data = category,
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Result<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid categoryId, [FromBody] CategoryDto category)
        {
            try
            {
                var existingCategory = await _unitOfWork.Category.GetByIdAsync(categoryId);
                if (existingCategory == null)
                {
                    return NotFound(new Result<object>
                    {
                        Success = false,
                        Message = "Category not found."
                    });
                }
                await _unitOfWork.Category.UpdateAsync(existingCategory);
                int saveResponse = await _unitOfWork.SaveAsync();
                var message = saveResponse > 0 ? $"Category '{category.Name}' has been updated successfully."
                                               : $"Failed to update the category '{category.Name}'.";
                return Ok(new Result<object>
                {
                    Success = true,
                    Message = message,
                    Data = category
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Result<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            try
            {
                var category = await _unitOfWork.Category.GetByIdAsync(categoryId);

                if (category == null)
                {
                    return NotFound(new Result<object>
                    {
                        Success = false,
                        Message = "Category not found.",
                    });
                }

                await _unitOfWork.Category.DeleteAsync(category);
                int saveResponse = await _unitOfWork.SaveAsync();

                var message = saveResponse > 0 ? $"Category '{category.Name}' has been deleted successfully."
                                               : $"Failed to delete the category '{category.Name}'.";
                return Ok(new Result<object>
                {
                    Success = true,
                    Message = message,
                    Data = CategoryMapper.ToDto(category),
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Result<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

    }
}