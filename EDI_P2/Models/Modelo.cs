using System;

using System.Data.Entity;

namespace EDI_P2.Models
{
    public class Modelo
    {

        public string Equipo { get; set; }
        public string Coach { get; set; }
        public string Liga { get; set; }
        public string Fecha { get; set; }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public object Obs { get; internal set; }
    }
    public class MovieDBContext : DbContext
    {
        public DbSet<Modelo> Teams { get; set; }
    }
}
