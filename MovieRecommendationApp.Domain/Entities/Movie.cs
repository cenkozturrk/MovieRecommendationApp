using MovieRecommendationApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Domain.Entities
{
    //[Table("MovieRecomm")]
    public class Movie : BaseEntity
    {
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(25), MinLength(5)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(20), MinLength(5)]
        public string? OriginalLanguage { get; set; }

        [Required(ErrorMessage = "{0}is required.")]
        [MaxLength(15), MinLength(5)]
        public string? OriginalTitle { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(200), MinLength(20)]
        public string? OverView { get; set; }

        [Required(ErrorMessage = "{0}is required.")]
        public decimal Popularity { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Range(1, 10, ErrorMessage = "Vote cannot be less than 1 and greater than 10.")]
        public int VoteCount { get; set; }
    }
}
