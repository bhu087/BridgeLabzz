using Manager.Notes;
using Model.Account;
using Moq;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTesting.Notes
{
    public class NotesUnitTesting
    {
        [Fact]
        public void AddNotesTest1()
        {
            var service = new Mock<INotesRepo>();
            var manager = new NotesManager(service.Object);
            var add = new NotesModel()
            {
                Title = "Bahala",
                Description = "Kadime",
                CreatedTime = DateTime.Now
            };
            var data = manager.AddNotes(add);
            Assert.NotNull(data);
        }
    }
}
