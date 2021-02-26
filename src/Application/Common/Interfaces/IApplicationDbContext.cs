using Microsoft.EntityFrameworkCore;
using Ophelia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Ophelia.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IBaseDbContext
    {
        DbSet<Existencia> existencias { get; set; }
        DbSet<Articulo> articulos { get; set; }
        DbSet<Cliente> clientes { get; set; }
        DbSet<DetalleVenta> detalleventas { get; set; }
        DbSet<TipoDocumento> tipodocumentos { get; set; }
        DbSet<Unidad> unidades { get; set; }
        DbSet<Venta> ventas { get; set; }
    }
}
