namespace MeuProjetoWinForms.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeeLogin { get; set; }
        public string EmployeePassword { get; set; }
        public bool EmployeeStatus { get; set; }

        
        public EmployeeDto() { }

       
        public EmployeeDto(string fullName, string login, string password)
        {   
            EmployeeFullName = fullName;
            EmployeeLogin = login;
            EmployeePassword = password;
            EmployeeStatus = true;
        }
    }
}
