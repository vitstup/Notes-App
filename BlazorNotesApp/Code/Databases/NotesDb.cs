using BlazorNotesApp.Code.Models;
using SQLite;

namespace BlazorNotesApp.Code.Databases
{
	public class NotesDb
	{
		private readonly SQLiteAsyncConnection db;

		public NotesDb(string connectionString)
		{
			db = new SQLiteAsyncConnection(connectionString);

			db.CreateTableAsync<Note>().Wait();
		}

		public async Task<IEnumerable<Note>> GetNotes()
		{
			return await db.Table<Note>().ToListAsync();
		}

		public async Task<Note> GetNoteById(int id)
		{
			return await db.Table<Note>().Where(i => i.id == id).FirstOrDefaultAsync();
		}

		public async Task SaveNote(Note note)
		{
			if (note == null) return;

			if (note.id != 0) await db.UpdateAsync(note);
			else await db.InsertAsync(note);
		}

		public async Task RemoveNoteById(int id)
		{
			var note = await GetNoteById(id);
			await db.DeleteAsync(note);
		}

		public async Task RemoveNote(Note note)
		{
			await db.DeleteAsync(note);
		}
	}
}