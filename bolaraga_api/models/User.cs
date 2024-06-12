using System.ComponentModel.DataAnnotations;

namespace bolaraga_api.models
{
    public class User
    {
        [Key]
        public int Id_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nomor { get; set; }
    }
}
