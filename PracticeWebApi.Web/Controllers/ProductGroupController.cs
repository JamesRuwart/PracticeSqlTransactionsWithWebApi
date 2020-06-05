using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeWebApi.CommonClasses.Exceptions;
using PracticeWebApi.CommonClasses.Products;
using PracticeWebApi.Services;
using System;
using System.Threading.Tasks;

namespace PracticeWebApi.Web.Controllers
{
    public class ProductGroupController : Controller
    {
        private readonly IProductGroupService _productGroupService;

        public ProductGroupController(IProductGroupService productGroupService)
        {
            _productGroupService = productGroupService;
        }

        [HttpPost("/groups")]
        public async Task<IActionResult> AddProductGroup([FromBody]ProductGroup productGroup)
        {
            try
            {
                var addedGroup = await _productGroupService.AddProductGroup(productGroup);
                return Ok(addedGroup);
            }
            catch(DuplicateResourceException exception)
            {
                return BadRequest(exception);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet("/groups")]
        public async Task<IActionResult> GetAllProductGroups()
        {
            try
            {
                var groups = await _productGroupService.GetAllProductGroups();
                return Ok(groups);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpDelete("/groups/{id}")]
        public async Task<IActionResult> DeleteProductGroup([FromRoute]string id)
        {
            try
            {
                await _productGroupService.DeleteProductGroup(id);

                return Ok();
            }
            catch (ResourceNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}