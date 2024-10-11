using Microsoft.EntityFrameworkCore;

namespace FINSCOPE.Data
{
    public class FINSCOPEContext : DbContext
    {
        public FINSCOPEContext(DbContextOptions<FINSCOPEContext> options)
            : base(options)
        {
        }
    }
}