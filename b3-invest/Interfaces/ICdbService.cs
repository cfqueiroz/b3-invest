using calculo_b3.Models;

namespace calculo_b3.Services
{
    public interface ICdbService
    {
        CdbResponse CalculaCDB(CdbRequest cdbRequest);
    }
}
