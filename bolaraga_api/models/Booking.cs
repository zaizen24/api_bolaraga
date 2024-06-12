using System.ComponentModel.DataAnnotations;

namespace bolaraga_api.models
{
    public class Booking
    {
        [Key]
        public int id_booking { get; set; }
        public int id_lap { get; set; }
        public string nama_lap { get; set; }
        public DateOnly tanggal_main {  get; set; }
        public TimeSpan jam_main {  get; set; }
        public int durasi {  get; set; }
        public string metode_pembayaran {  get; set; }
        public string username { get; set; }
    }
}
