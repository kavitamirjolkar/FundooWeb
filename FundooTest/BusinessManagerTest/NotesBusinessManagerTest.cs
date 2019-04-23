// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesBusinessManagerTest.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooTest.BusinessManagerTest
{
    using System;
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
            ////arrange
            var service = new Mock<INotesRepository>();
            var notes = this.GetFakeData();
            service.Setup(x => x.GetAllNotesAsync()).Returns(notes);
            var notesBusinessLayer = new NotesBusinessManager(service.Object);

            ////act
            var results = notesBusinessLayer.GetAllNotesAsync();
            var count = results.Count();

            ////assert
            Assert.Equal(200, count);
        }

        [Fact]
        public void Add()
        {
            ////arrange
            var service = new Mock<INotesRepository>();
            var notes = new NotesBusinessManager(service.Object);
            var addNotes = new NotesModel()
            {
                Id = 0,
                Title = "Title",
                Description = "Description",
                UserId = System.Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            ////act
            var data = notes.AddNotesAsync(addNotes);

            ////assert
            Assert.NotNull(data);
        }

        [Fact]
        public void Delete()
        {
            ////arrange
            var service = new Mock<INotesRepository>();
            var notes = new NotesBusinessManager(service.Object);
            ////act
            var data = notes.DeleteAsync(2);
            ////assert
            Assert.NotNull(data);
        }


        [Fact]
        public void Update()
        {
            ////arrange
            var service = new Mock<INotesRepository>();
            var notes = new NotesBusinessManager(service.Object);
            var addNotes = new NotesModel()
            {
                Id = 0,
                Title = "Title",
                Description = "Title",
                UserId = System.Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            ////act
            var data = notes.UpdateAsync(addNotes, 2);
            ////assert
            Assert.NotNull(data);
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

