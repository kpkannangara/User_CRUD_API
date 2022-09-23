﻿using System.ComponentModel.DataAnnotations;

namespace UserCRUDAPI.Models
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
