/////------------------------------------------------------------------------
////<copyright file="LabelUnitTesting.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace UnitTesting.Labels
{
    using Manager.Labels;
    using Model.Account;
    using Moq;
    using Repository.IRepo;
    using Xunit;

    /// <summary>
    /// This is the label unit testing
    /// </summary>
    public class LabelUnitTesting
    {
        /// <summary>
        /// Adds the label test.
        /// </summary>
        [Fact]
        public void AddLabelTest()
        {
            var service = new Mock<ILabelRepo>();
            var label = new LabelManager(service.Object);
            var labelModel = new LabelModel() {
                LabelId = 1001,
                LabelName = "Hello"
            };
            var result = label.AddLabel(labelModel);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Deletes the label test.
        /// </summary>
        [Fact]
        public void DeleteLabelTest()
        {
            var service = new Mock<ILabelRepo>();
            var label = new LabelManager(service.Object);

            var result = label.DeleteLabel("Hello");
            Assert.NotNull(result);
        }

        /// <summary>
        /// Deletes the note from label.
        /// </summary>
        [Fact]
        public void DeleteNoteFromLabel()
        {
            var service = new Mock<ILabelRepo>();
            var label = new LabelManager(service.Object);
            var id = 1003;
            var result = label.DeleteNoteFromLabel(id);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Updates the label test.
        /// </summary>
        [Fact]
        public void UpdateLabelTest()
        {
            var service = new Mock<ILabelRepo>();
            var label = new LabelManager(service.Object);
            var id = 1003;
            var labelName = "Hello";
            var labelModel = new LabelModel()
            {
                LabelId = 1001,
                LabelName = "Hello"
            };
            var result = label.UpdateLabel(id, labelName, labelModel);
            Assert.NotNull(result);
        }
    }
}
