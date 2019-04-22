// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesBusinessManagerTest.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooTest.BusinessManagerTest
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Model;
    using FundooBusiness.Services;
    using FundooRepository.Interfaces;
    using GenFu;
    using Moq;  
    using Xunit;

    /// <summary>
    /// This is test class
    /// </summary>
    public class NotesBusinessManagerTest
    {
        /// <summary>
        /// this function is to test get note
        /// </summary>
        [Fact]
        public void GetNotesTest()
        {
            var service = new Mock<INotesRepository>();
            var notes = this.GetFakeData();
            service.Setup(x => x.GetAllNotesAsync()).Returns(notes);
            var notesBusinessLayer = new NotesBusinessManager(service.Object);

            var results = notesBusinessLayer.GetAllNotesAsync();

            var count = results.Count();

            Assert.Equal(200, count);
        }

        /// <summary>
        /// This fake data function
        /// </summary>
        /// <returns>returns response</returns>
        private IEnumerable<NotesModel> GetFakeData()
        {
            var i = 1;
            var notes = A.ListOf<NotesModel>(200);
            notes.ForEach(x => x.Id = i++);
            return notes.Select(_ => _);
        }
    }
}
