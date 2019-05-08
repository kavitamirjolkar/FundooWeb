namespace FundooTest.BusinessManagerTest
{
    using FundooBusiness.Services;
    using FundooRepository.Interfaces;
    using Moq;   
    using Xunit;

    /// <summary>
    /// Test class for labels
    /// </summary>
    public class Labels
    {
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        [Fact]
        public void Delete()
        {
            ////arrange
            var service = new Mock<ILabelsRepository>();
            var notes = new LabelBusiness(service.Object);
            ////act
            var data = notes.DeleteLabel(2);
            ////assert
            Assert.NotNull(data);
        }
    }
}
