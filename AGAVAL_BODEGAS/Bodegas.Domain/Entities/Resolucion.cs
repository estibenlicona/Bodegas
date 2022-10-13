namespace Bodegas.Domain.Entities
{
    public class Resolucion : BaseEntity
    {
        public string CodigoCaja { get; set; } = default!;
        public string cod_apl { get; set; } = default!;
        public string cod_con { get; set; } = default!;
        public string resol { get; set; } = default!;
        public string res_ini { get; set; } = default!;
        public string res_fin { get; set; } = default!;
        public string des_con { get; set; }
        public decimal? num_ini { get; set; }
        public string car_con { get; set; } = default!;
        public decimal? num_act { get; set; }
        public short lon_con { get; set; }
        public DateTime? fecha { get; set; }

        public Resolucion()
        {
            des_con = $"CAJA{CodigoCaja}";
            num_ini = 1;
            lon_con = 10;
            num_act = 0;
        }
    }
}
