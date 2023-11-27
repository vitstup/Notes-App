using SQLite;

namespace BlazorNotesApp.Code.Models
{
	public class Note
	{
		[AutoIncrement, PrimaryKey]
		public int id {  get; set; }
		public string title { get; set; }
		public string body { get; set; }
		public DateTime publishedAt { get; set; }
		public bool wasChanged { get; set; }
	}
}