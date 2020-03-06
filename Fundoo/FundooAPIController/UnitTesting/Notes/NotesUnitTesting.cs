/////------------------------------------------------------------------------
////<copyright file="NotesUnitTesting.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace UnitTesting.Notes
{
    using Moq;
    using Xunit;
    using Model.Account;
    using Repository.IRepo;
    using Manager.Notes;

    /// <summary>
    /// This is the unit testing for Notes
    /// </summary>
    public class NotesUnitTesting
    {
        /// <summary>
        /// Adds the notes test1.
        /// </summary>
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

        /// <summary>
        /// Updates the notes.
        /// </summary>
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

        /// <summary>
        /// Deletes the notes.
        /// </summary>
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
