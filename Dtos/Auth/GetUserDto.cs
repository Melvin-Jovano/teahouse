using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teahouse.Models;

namespace teahouse.Dtos.Auth {
    public class GetUserDto {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public int Balance { get; set; }
    }
}