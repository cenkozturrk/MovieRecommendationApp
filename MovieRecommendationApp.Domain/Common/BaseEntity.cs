using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }


        //Kaydı gerçekte silmeyeceğiz. Sadece aktif durumdan pasif duruma çekeceğiz.(Soft Delete)
        public bool IcActive { get; set; }
    }
}
