namespace Bodegas.Domain.Entities
{
    public class Caja : BaseEntity
    {
        public string Codigo { get; set; } = default!;
        public string nom_caj { get; set; } = default!;
        public string cod_bod { get; set; } = default!;
        public decimal? base_caj { get; set; } = default!;
        public string cod_cco { get; set; } = default!;
        public string? cod_cl1 { get; set; } = default!;
        public string? cod_cl2 { get; set; } = default!;
        public string? cod_cl3 { get; set; } = default!;
        public int? num_ini { get; set; }
        public string car_con { get; set; } = default!;
        public int? num_act { get; set; }
        public short? lon_con { get; set; }
        public int? ind_facelectronica { get; set; }
        public string cod_ban { get; set; }
        public Caja()
        {
            num_ini = 0;
            lon_con = 10;
            cod_ban = "0";
            ind_facelectronica = 0;
            num_act = 0;
        }
    }
}
