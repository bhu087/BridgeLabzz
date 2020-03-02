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
    }
}
