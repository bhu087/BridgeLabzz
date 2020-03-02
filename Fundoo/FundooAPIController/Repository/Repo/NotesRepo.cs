using Model.Account;
using Repository.Context;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class NotesRepo : INotesRepo
    {
        public readonly UserDBContext context;
        public NotesRepo(UserDBContext userDBContext)
        {
            this.context = userDBContext;
        }
        public async Task<string> AddNotes(NotesModel notesModel)
        {
            try
            {
                NotesModel add = new NotesModel()
                {
                    Email = notesModel.Email,
                    Title = notesModel.Title,
                    Description = notesModel.Description,
                    CreatedTime = notesModel.CreatedTime,
                };
                this.context.Notes.Add(add);
                var result = this.context.SaveChangesAsync();
                return "Saved";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> UpdateNotes(NotesModel notesModel)
        {
            try
            {
                if (this.FindById(notesModel.NotesId1))
                {
                    var notesCheck = this.context.Notes.Where(notesId => notesId.NotesId1 == notesModel.NotesId1).SingleOrDefault();
                    notesCheck.Email = notesModel.Email;
                    notesCheck.Title = notesModel.Title;
                    notesCheck.Description = notesModel.Description;
                    notesCheck.ModifiedTime = notesModel.ModifiedTime;
                    var result = this.context.SaveChangesAsync();
                    return "Saved";
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool FindById(int id)
        {
            try
            {
                var notesCheck = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                if (notesCheck.NotesId1 == id)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public Task<int> DeleteNotes(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    note.IsTrash = true;
                    var result = this.context.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> DeleteTrash(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(noteId => noteId.NotesId1 == id).SingleOrDefault();
                    if (note.IsTrash)
                    {
                        this.context.Notes.Remove(note);
                        var result = this.context.SaveChangesAsync();
                        return "Deleted from Trash";
                    }
                    return "This Note is Not Trash";
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Task<int> ArchieveNotes(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    note.IsArchive = true;
                    var result = this.context.SaveChangesAsync();
                    return result;
                }
                return null; 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> DeleteArchievedNote(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    if (note.IsArchive)
                    {
                        note.IsTrash = true;
                        var result = this.context.SaveChangesAsync();
                        return "Deleted";
                    }
                    return "No";
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Task<int> SetRemainder(int id, string time)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    note.Remainder = time;
                    var result = this.context.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
