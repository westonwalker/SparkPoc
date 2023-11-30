using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Data;

public static class Database
{
    public static List<Contact> Contacts = new()
    { 
        new Contact { Id = 1, Name = "Kramer", Email = "kramer@gmail.com", City = "New York", Phone = "3927374545" },
		new Contact { Id = 2, Name = "Jerry", Email = "Jerry@gmail.com", City = "Queens", Phone = "3954563237" }
	};

}

public class Contact
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
	[Required] public string Email { get; set; }
	[Required] public string City { get; set; }
	[Required] public string Phone { get; set; }
}
