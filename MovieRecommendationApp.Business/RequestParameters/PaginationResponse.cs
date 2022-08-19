using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.RequestParameters
{
    public record PaginationResponse
    {
        // Karşılayıcı bir requestparamters nesnesi olacagından class(record) yapmayı gerek duymadım.Maliyet kırma ve data daha önde.
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
