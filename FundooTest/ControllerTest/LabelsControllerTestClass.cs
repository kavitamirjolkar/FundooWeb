namespace FundooTest.ControllerTest
{
    using Common.Model;
    using FundooApi.Controllers;
    using FundooBusiness.Interfaces;
    using Moq;
    using Xunit;

    /// <summary>
    /// test class for labels
    /// </summary>
    public class LabelsControllerTestClass
    {
        /// <summary>
        /// Adds the labels.
        /// </summary>
        [Fact]
        public void AddLabels()
        {
            ////arrange
            var service = new Mock<ILabelsBusiness>();
            var controller = new LabelsController(service.Object);
            var label = new LabelModel()
            {
                Id = 0,
                Label = "Label",               
            };

            ////act
            var data = controller.AddLabels(label);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        [Fact]
        public void Delete()
        {
            ////arrange
            var service = new Mock<ILabelsBusiness>();
            var notes = new LabelsController(service.Object);
            ////act
            var data = notes.Deletelabel(2);
            ////assert
            Assert.NotNull(data);
        }      
    }
}
