using bos.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace csharp_rest.Tests
{
    public class LocationTest
    {
        [Fact]
        public void ValidateInvalidId()
        {
            Location loc = new Location();
            loc.LocationId = -2;
            loc.Name = "low id";
            //var context = new ValidationContext(u, serviceProvider: null, items: null);
            ValidationContext context = new ValidationContext(loc);
            var validationResults = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(loc, context, validationResults, true));            
        }

        [Fact]
        public void ValidateDefaultId()
        {
            Location loc = new Location();
            loc.Name = "Low Id";
            ValidationContext context = new ValidationContext(loc);
            var validationResults = new List<ValidationResult>();

            Assert.True(Validator.TryValidateObject(loc, context, validationResults, true));
        }

        [Fact]
        public void ValidateNoName()
        {
            Location loc = new Location();
            ValidationContext context = new ValidationContext(loc);
            var validationResults = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(loc, context, validationResults, true));
        }

        [Fact]
        public void AddOneUse()
        {
            Location loc = new Location();
            loc.Name = "Add One Use";
            UseType use = new UseType(1, "Hiking", "All about da feet");
            loc.AddUse(use);

            Assert.Single(loc.GetUses());
        }

        [Fact]
        public void AddNUses()
        {
            Location loc = new Location();
            loc.Name = "Add One Use";
            UseType use = new UseType(1, "First", "First One");
            loc.AddUse(use);
            use = new UseType(2, "Second", "Second One");
            loc.AddUse(use);

            Assert.Equal(2, loc.GetUses().Count);
        }

        [Fact]
        public void AddDuplicateUses()
        {
            Location loc = new Location();
            loc.Name = "Add One Use";
            UseType use = new UseType(1, "First", "First One");
            loc.AddUse(use);

            Assert.False(loc.AddUse(use));
            Assert.Single(loc.GetUses());
        }

    }


}
