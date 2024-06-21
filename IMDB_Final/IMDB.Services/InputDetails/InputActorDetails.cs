using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.InputDetails
{
    public class InputActorDetails
    {
        public static DateOnly GetActorBirthDate()
        {
            Console.WriteLine("Enter the birth date of the actor in the given format -> (dd/mm/yyyy): ");
            var providedDateOfBirth = "";
            var isValidDOB = false;
            while(isValidDOB == false)
            {
                providedDateOfBirth = Console.ReadLine();
                DateOnly givenDOB;
                if(DateOnly.TryParse(providedDateOfBirth, out givenDOB) && givenDOB.Year >= 1800 && givenDOB < DateOnly.FromDateTime(DateTime.Now))
                {
                    isValidDOB = true;
                }
                else
                {
                    Console.WriteLine("Invalid Date of Birth. Please try again and enter a valid date of birth: ");
                }
            }
            var DateOfBirth = DateOnly.Parse(providedDateOfBirth);
            return DateOfBirth;

        }

        public static string GetActorName()
        {
            Console.WriteLine("Enter the name of the actor you want to add in the IMDB: ");
            var providedActorName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(providedActorName))
            {
                Console.WriteLine("Please Enter valid name of the actor");
                providedActorName = Console.ReadLine();
            }
            return providedActorName;
        }
    }
}
