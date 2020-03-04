using CloudinaryDotNet.Actions;
using Model.Account;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            try
            {
                return this.notesRepo.GetAllNotes();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<NotesModel> GetNotesById(int id)
        {
            try
            {
                return this.notesRepo.GetNotesById(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<ImageUploadResult> UploadImage(int id,string imagePath)
        {
            try
            {
                return this.notesRepo.UploadImage(id, imagePath);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IQueryable<NotesModel> Search(string searchParameter)
        {
            try
            {
                return this.notesRepo.Search(searchParameter);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<string> AddCollaborator(int noteId, string collaboratorEmail)
        {
            try
            {
                return this.notesRepo.AddCollaborator(noteId, collaboratorEmail);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<string> DeleteCollaborator(int id)
        {
            try
            {
                return this.notesRepo.DeleteCollaborator(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        //public Task<string> DownloadImage(int id)
        //{
        //    try
        //    {
        //        return this.notesRepo.DownloadImage(id);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}
    }
}
