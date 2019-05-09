using System.Collections.Generic;

namespace clientapi.models {
    public class Rating {
        public long RatingId { get; set;}
        public int Stars { get; set;}
        public Item Item { get; set;}
     
    }

}
