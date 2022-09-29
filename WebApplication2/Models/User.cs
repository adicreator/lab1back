using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class User
    {
        public int UsersId { get; set; }
        public string? Emri { get; set; }
        public string? Mbiemri { get; set; }
        public string? NrTel { get; set; }
        public string? Username { get; set; }
        public string? Passwordi { get; set; }
        public string? Roli { get; set; }
    }
}
