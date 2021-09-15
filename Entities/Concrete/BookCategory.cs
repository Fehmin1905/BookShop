using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BookCategory:IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [JsonIgnore]
        public List<Book> Books { get; set; }
    }
}
