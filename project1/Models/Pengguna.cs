using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace project1.Models
{
    public class Pengguna
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage ="Nama Tidak Bleh Kosong")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Email Tidak Boleh kosng")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Tidak Boleh Kosong")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password Tidak Cocok")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}