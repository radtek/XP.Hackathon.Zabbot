using XP.Hackathon.Zabbot.Interface.DTO;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using XP.Hackathon.Zabbot.Model.Filter;
using System.Threading.Tasks;
using XP.Hackathon.Zabbot.DTO;

namespace XP.Hackathon.Zabbot.Api.Controllers
{
    [Route("api/zabbot/[controller]")]
    //[Authorize]
    public class ProductController : BaseController<Product, ProductMessage>
    {
        private readonly IProductService _service;
        private readonly IDTO<Product, ProductMessage> _productDTO;

        public ProductController(IProductService service, IProductDTO productDTO) : base(service, productDTO)
        {
            this._service = service;
            this._productDTO = productDTO;
        }

        [HttpGet]
        [Route("detail")]
        public async Task<ObjectResult> GetDetailAsync(BaseFilter filter)
        {
            var response = await _service.GetDetailAsync(filter);

            if (!response.Success && response.Error != null)
                return await ResponseInternalServerError(response.FriendlyMessage + response.MessageLog);

            if (!response.Success)
                return await ResponseNotFound();

            return await ResponseOk(_productDTO.ToMessage(response.Objects));
        }
    }
}
