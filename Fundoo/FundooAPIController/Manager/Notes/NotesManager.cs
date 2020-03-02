using Model.Account;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Notes
{
    public class NotesManager : INotesManager
    {
        public readonly INotesRepo notesRepo;
        public NotesManager(INotesRepo notesRepo)
        {
            this.notesRepo = notesRepo;
        }
        public Task<string> AddNotes(NotesModel notesModel)
        {
            return this.notesRepo.AddNotes(notesModel);
        }

        public Task<string> DeleteTrash(int id)
        {
            return this.notesRepo.DeleteTrash(id);
        }

        public Task<int> DeleteNotes(int id)
        {
            try
            {
                return this.notesRepo.DeleteNotes(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<int> ArchieveNotes(int id)
        {
            try
            {
                return this.notesRepo.ArchieveNotes(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<string> DeleteArchievedNote(int id)
        {
            try
            {
                return this.notesRepo.DeleteArchievedNote(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
