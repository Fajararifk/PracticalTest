using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PracticalTest.BusinessObjects
{
    public class SportEventsValidator : AbstractValidator<SportEvents>
    {
        private readonly PracticalTest_DBContext _dbContext;
        public SportEventsValidator(PracticalTest_DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public SportEventsValidator() 
        {
            RuleFor(model => model.EventDate)
                .Must(IsDateValid)
                .GreaterThan(DateTime.Now)
                .WithMessage("This Event Date must greater than today");
            RuleFor(model => model.EventName)
                .Must(UniqueName)
                .WithMessage("This Event name already exists");
            RuleFor(model => model.EventName)
                .MinimumLength(250)
                .WithMessage("This Event name should not be more 250 characters");
            RuleFor(model => model.Organizers).NotEmpty();

        }
        private bool UniqueName(SportEvents sportEvents, string name)
        {
            var dbSportEvents = _dbContext.SportsEvents.Where(x => x.EventName.ToLower() == name.ToLower()).SingleOrDefault();
            if(dbSportEvents == null)
                return true;
            return dbSportEvents.EventName == sportEvents.EventName;
        }
        private bool IsDateValid(DateTime eventDate)
        {
            return eventDate.Date > DateTime.Now.Date;
        }
    }
    
}
