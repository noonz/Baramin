using System;
using SQLite;

namespace Baramin.Models
{
    [Table("Items")]
    public class Favourite
    {
        [PrimaryKey, Column("_id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Type { get; set; }

        public Favourite()
        {
        }
    }
}
