using SparkPoc.Application.Models;

namespace SparkPoc.Pages.Components;

public class PageState
{
	public User User { get; set; } = new();
	public string AppName { get; set; }
}