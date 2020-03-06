using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using NotesCases;
using Xunit;
using Repository.Repo;
using Manager.Account;
using Model.Account;
using Repository.IRepo;
using Manager.Notes;

namespace UnitTesting.Notes
{
    public class NotesUnitTesting
    {
        [Fact]
        public void AddNotesTest1()
        {
            var service = new Mock<INotesRepo>();
            var manager = new NotesManager(service.Object);
            NotesModel notesModel = new NotesModel() {
                Email = "Bhu000@gmail.com",
                NotesId1 = 10,
                Title = "The earth",
            };
            var result = manager.AddNotes(notesModel);
            Assert.NotEqual(1, result.Result);
        }
        [Fact]
        public void UpdateNotes()
        {
            var service = new Mock<INotesRepo>();
            var manager = new NotesManager(service.Object);
            NotesModel notesModel = new NotesModel()
            {
                Title = "The earth",
                Description = "Nature is god",
                IsArchive = true
            };
            var result = manager.UpdateNotes(notesModel);
            Assert.NotNull(result);
        }
        [Fact]
        public void DeleteNotes()
        {
            var service = new Mock<INotesRepo>();
            var manager = new NotesManager(service.Object);
            var result = manager.DeleteNotes(10);
            Assert.NotNull(result);
        }
    }
}
