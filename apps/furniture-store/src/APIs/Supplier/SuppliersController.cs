using Microsoft.AspNetCore.Mvc;

namespace FurnitureStore.APIs;

[ApiController()]
public class SuppliersController : SuppliersControllerBase
{
    public SuppliersController(ISuppliersService service)
        : base(service) { }
}
