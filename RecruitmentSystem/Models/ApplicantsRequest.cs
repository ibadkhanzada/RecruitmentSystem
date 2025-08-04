using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class ApplicantsRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Region is required")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Area of Expertise is required")]
        public string AreaOfExpertise { get; set; }

        [Required(ErrorMessage = "Years of Experience is required")]
        [Range(0, 50, ErrorMessage = "Enter a valid number of years")]
        public int YearsOfExperience { get; set; }

        public string? CvFilePath { get; set; }

        [Required(ErrorMessage = "LinkedIn Profile is required")]
        public string LinkedInProfile { get; set; }

        public string AdditionalComments { get; set; }
    }
}
