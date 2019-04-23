// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerTestClass.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooTest.ControllerTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Model;
    using FundooApi.Controllers;
    using FundooBusiness.Interfaces;
    using GenFu;
    using Microsoft.AspNetCore.Mvc;
    using Moq;  
    using Xunit;

    /// <summary>
    /// This class is to test controller
    /// </summary>
    public class ControllerTestClass
    {
        /// <summary>
        /// Gets the notes test.
        /// </summary>
        [Fact]
        public void GetNotesTest()
        {
            //// arrange
            var service = new Mock<INotesBusinessManager>();
            var notes = this.GetFakeData();

            service.Setup(x => x.GetAllNotesAsync()).Returns(notes);
            var controller = new NotesController(service.Object);

            ////act
            var results = controller.GetAllNotes();
            var count = results.Count();

            ////assert
            Assert.Equal(200, count);
        }

        /// <summary>
        /// Tasks the add valid data return ok result.
        /// </summary>
        [Fact]
        public  void Task_Add_ValidData_Return_OkResult()
        {
            ////arrange
            var service = new Mock<INotesBusinessManager>();
            var controller = new NotesController(service.Object);
            var notes = new NotesModel()
            {
                Id=0,
                Title = "Title",
                Description = "Description",
                UserId = System.Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedDate=DateTime.Now
            };

            ////act
            var data = controller.Add(notes);
            
            ////assert
            Assert.NotNull(data);
        }


        [Fact]
        public void Delete()
        {
            ////arrange
            var service = new Mock<INotesBusinessManager>();
            var notes = new NotesController(service.Object);
            ////act
            var data = notes.Delete(2);
            ////assert
            Assert.NotNull(data);
        }

        [Fact]
        public void Update()
        {
            ////arrange
            var service = new Mock<INotesBusinessManager>();
            var notes = new NotesController(service.Object);
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
            var data = notes.UpdateNotes(addNotes, 2);
            ////assert
            Assert.NotNull(data);
        }
       
        /// <summary>
        /// Gets the fake data.
        /// </summary>
        /// <returns>returns notes</returns>
        private IEnumerable<NotesModel> GetFakeData()
        {
            var i = 1;
            var notes = A.ListOf<NotesModel>(200);
            notes.ForEach(x => x.Id = i++);
            return notes.Select(_ => _);
        }
    }
}