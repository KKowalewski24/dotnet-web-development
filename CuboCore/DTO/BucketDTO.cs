using System;
using System.Collections.Generic;

namespace CuboCore.DTO {

    public class BucketDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<string> Items { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public BucketDTO() {
        }

        public BucketDTO(string name, DateTime createdAt, IList<string> items) {
            Name = name;
            CreatedAt = createdAt;
            Items = items;
        }

    }

}
