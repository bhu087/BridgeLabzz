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

        public Task<int> SetRemainder(int id, string time)
        {
            try
            {
                return this.notesRepo.SetRemainder(id, time);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<string> UpdateNotes(NotesModel notesModel)
        {
            try
            {
                return this.notesRepo.UpdateNotes(notesModel);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<int> DeleteRemainder(int id)
        {
            try
            {
                return this.notesRepo.DeleteRemainder(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<string> EditTitle(NotesModel notesModel)
        {
            try
            {
                return this.notesRepo.EditTitle(notesModel);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<string> SetColor(int id, string color)
        {
            try
            {
                return this.notesRepo.SetColor(id, color);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<NotesModel> GetAllNotes()
        {
            return this.notesRepo.GetAllNotes();
        }
    }
}
