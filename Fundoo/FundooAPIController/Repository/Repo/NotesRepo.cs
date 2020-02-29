using Model.Account;
using Repository.Context;
using Repository.IRepo;
using System;
using System.Collections.Generic;
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
    }
}
