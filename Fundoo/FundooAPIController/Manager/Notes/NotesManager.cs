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
        INotesRepo notesRepo;
        public NotesManager(INotesRepo notesRepo)
        {
            this.notesRepo = notesRepo;
        }
        public Task<string> AddNotes(NotesModel notesModel)
        {
            return this.notesRepo.AddNotes(notesModel);
        }
    }
}
