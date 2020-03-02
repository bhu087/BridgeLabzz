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
    }
}
