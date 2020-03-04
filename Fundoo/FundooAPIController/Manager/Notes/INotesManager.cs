using CloudinaryDotNet.Actions;
using Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
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
        Task<ImageUploadResult> UploadImage(int id, string imagePath);
        //Task<string> DownloadImage(int id);
        IQueryable<NotesModel> Search(string searchParameter);
        Task<string> AddCollaborator(int noteId, string collaboratorEmail);
    }
}
