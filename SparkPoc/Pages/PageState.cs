using SparkPoc.Application.Models;

namespace SparkPoc.Pages;

public class PageState
{
	public User User { get; set; } = new();
	public string AppName { get; set; }
}