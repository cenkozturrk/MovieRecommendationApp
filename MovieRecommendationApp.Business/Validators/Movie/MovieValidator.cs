using FluentValidation;
using MovieRecommendationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage(" Please enter the movie name..! ")
                .MaximumLength(50)
                .MinimumLength(5)
                    .WithMessage(" Please enter the movie name between 5 and 50 characters..! ");

            RuleFor(m => m.OriginalLanguage)
                .NotEmpty()
                .NotEmpty()
                    .WithMessage(" Please enter the original language ..! ")
                .MaximumLength(30)
                .MinimumLength(5)
                    .WithMessage(" Please enter the movie original language between 5 and 30 characters..! ");

            RuleFor(m => m.VoteCount)
                .NotEmpty()
                .NotNull()
                    .WithMessage(" Please enter the vote count..! ")
                .Must(m => m > 0)
                .Must(m => m <= 10)
                    .WithMessage(" Vote count must be between 0 and 10..! ");
    


        }
    }
}
