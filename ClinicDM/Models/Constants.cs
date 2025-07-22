namespace ClinicDM.Models {
    public class Constants {
        public static List<Patient> Patients = new List<Patient> {
            new Patient {
                DateOfBirth = new DateOnly(1990, 1, 1),
                Id = 1,
                FullName = "John Doe",
                NationalId = "123456789",
                Email = "jd@gmail.com",
                PhoneNumber = "123-456-7890"
            },
            new Patient {
                DateOfBirth = new DateOnly(1980, 1, 1),
                Id = 2,
                FullName = "John Dont",
                NationalId = "123456789",
                Email = "jd@gmail.com",
                PhoneNumber = "123-456-7890"
            },
            new Patient {
                DateOfBirth = new DateOnly(2000, 1, 1),
                Id = 3,
                FullName = "Wael Doe",
                NationalId = "999999",
                Email = "jd@gmail.com",
                PhoneNumber = "123-456-7890"
            }

        };
    }
}
