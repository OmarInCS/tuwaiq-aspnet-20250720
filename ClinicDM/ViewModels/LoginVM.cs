﻿using System.ComponentModel.DataAnnotations;

namespace ClinicDM.ViewModels {
    public class LoginVM {

        [EmailAddress]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
