using Model.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Notes
{
    public interface INotesManager
    {
        Task<string> AddNotes(NotesModel notesModel);
        Task<int> DeleteNotes(int id);
        Task<string> DeleteTrash(int id);
        Task<int> ArchieveNotes(int id);
        Task<string> DeleteArchievedNote(int id);
        Task<int> SetRemainder(int id, string time);
        Task<string> UpdateNotes(NotesModel notesModel);
        Task<int> DeleteRemainder(int id);
        Task<string> EditTitle(NotesModel notesModel);
        Task<string> SetColor(int id, string color);
        IEnumerable<NotesModel> GetAllNotes();
        Task<NotesModel> GetNotesById(int id);
    }
}
