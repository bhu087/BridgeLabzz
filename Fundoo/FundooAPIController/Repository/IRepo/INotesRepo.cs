using Model.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface INotesRepo
    {
        Task<string> AddNotes(NotesModel notesModel);
        Task<int> DeleteNotes(int id);
        Task<string> DeleteTrash(int id);
        Task<int> ArchieveNotes(int id);
    }
}
