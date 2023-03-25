using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project_Cinema.Models
{
    public partial class Rate
    {
        public int? MovieId { get; set; }
        public int? PersonId { get; set; }

        [Required(ErrorMessage = "Hãy để lại bình luận cho bộ phim nhé!")]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "Hãy đánh giá điểm cho bộ phim nhé!")]
        [Range(0, 10, ErrorMessage = "Hãy sử dụng thang điểm 10 để đánh giá bạn nhé!")]
        public double? NumericRating { get; set; }
        public DateTime? Time { get; set; }

        public virtual Movie? Movie { get; set; } = null!;
        public virtual Person? Person { get; set; } = null!;
    }
}
