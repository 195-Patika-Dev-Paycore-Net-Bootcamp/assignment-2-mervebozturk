namespace WebApi.Properties
{
    public class Employee
    {

            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string PhoneNumber { get; set; }
            public string DateofBirth { get; set; }
            public string Email { get; set; }
            public int Salary { get; set; }

            internal static object Where(Func<object, bool> value)
            {
                throw new NotImplementedException();
            }
        }
    }