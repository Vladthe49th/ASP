

namespace RazorCard.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        

        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }


        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;


                if (BirthDate.Date > today.AddYears(-age))
                    age--;

                return age;
            }
        }
    }

}