using CloudinaryDotNet.Actions;
using Model.Account;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.IO;
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
        //public Task<int> SaveImage(int id, string image)
        //{
        //    try
        //    {
        //        return this.notesRepo.SaveImage(id, image);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}

        //public async Task<string> DownloadImage(int id)
        //{
        //    try
        //    {
        //        string inputString = await this.notesRepo.DownloadImage(id);
        //        string filePath = @"D:\Abc\Download.png";
        //        File.WriteAllBytes(filePath, Convert.FromBase64String(inputString));
        //        return ("Saved to Abc folder");
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();
        //    } 
        //}
    }
}
