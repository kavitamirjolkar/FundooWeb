// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepositoryTest.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooTest.RepositoryTest
{
    using System.Collections.Generic;
    using System.Linq;   
    using Common.Model;
    using FundooRepository.DBContext;
    using FundooRepository.Service;
    using GenFu;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    /// <summary>
    /// this class is to test notes repository
    /// </summary>
    public class NotesRepositoryTest
    {
        /// <summary>
        /// All persons test.
        /// </summary>
        [Fact]
        public void AllPersonsTest()
        {
            var context = this.CreateDbContext();
            var service = new NotesRepository(context.Object);

            //// act
            var results = service.GetAllNotesAsync();
            var count = results.Count();
            //// assert
            Assert.Equal(26, count);
        }

        /// <summary>
        /// Creates the database context.
        /// </summary>
        /// <returns>returns fake data</returns>
        private Mock<AuthenticationContext> CreateDbContext()
        {
            var persons = this.GetFakeData().AsQueryable();
            var dbset = new Mock<DbSet<NotesModel>>();
            dbset.As<IQueryable<NotesModel>>().Setup(m => m.Provider).Returns(persons.Provider);
            dbset.As<IQueryable<NotesModel>>().Setup(m => m.Expression).Returns(persons.Expression);
            dbset.As<IQueryable<NotesModel>>().Setup(m => m.ElementType).Returns(persons.ElementType);
            dbset.As<IQueryable<NotesModel>>().Setup(m => m.GetEnumerator()).Returns(persons.GetEnumerator());
            var context = new Mock<AuthenticationContext>();
            context.Setup(c => c.Notes).Returns(dbset.Object);
            return context;
        }

        /// <summary>
        /// Gets the fake data.
        /// </summary>
        /// <returns>returns list</returns>
        private IEnumerable<NotesModel> GetFakeData()
        {
            var i = 1;
            var notes = A.ListOf<NotesModel>(26);
            notes.ForEach(x => x.Id = i++);
            return notes.Select(_ => _);
        }
    }
}
