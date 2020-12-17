using SQLite;

namespace TuttoNotes
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

