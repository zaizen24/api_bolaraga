using System.ComponentModel.DataAnnotations;

namespace bolaraga_api.models
{
    public class Jenis
    {
        [Key]
        public int id_jenis { get; set; }
        public string nama_jenis { get; set; }
    }
}

