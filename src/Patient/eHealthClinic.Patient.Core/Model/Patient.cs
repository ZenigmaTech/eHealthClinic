using System;
namespace eHealthClinic.Patient.Core.Model
{
	public class Patient
	{
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Mail { get; set; }
        public required string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }  
    }
}

