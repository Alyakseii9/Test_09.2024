namespace My_1_w.Application.Core.Entities
{
    public sealed class CatalogType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public CatalogType(string type)
        {
            Type = type;
        }
    }
    /*--на будущее?
     *     public class CatalogType : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
     */
}
