namespace ClinicDM.Models {
    public class Patient {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string NationalId { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
