using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class BookForUpdateDto:IDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime PublishTime { get; set; }
        public double Price { get; set; }
        public bool ShippingStatus { get; set; }
        public bool BookStatus { get; set; }//new or used
        public int BookCategoryId { get; set; }
    }
}
