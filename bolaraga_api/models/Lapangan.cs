using System.ComponentModel.DataAnnotations;

namespace bolaraga_api.models
{
    public class Lapangan
    {
        [Key]
        public int id_lap { get; set; }
        public string foto { get; set; }
        public int harga { get; set; }
        public string nama_lap { get; set;}
        public int id_jenis { get; set;}
    }
}
