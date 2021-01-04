using System;
using System.Collections.Generic;
using System.Linq;
using CuboCore.Exceptions.Item;

namespace CuboCore.Domain {

    public class Bucket : BaseEntity {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly ISet<Item> _items = new HashSet<Item>();

        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IEnumerable<Item> Items { get; private set; }

        /*------------------------ METHODS REGION ------------------------*/
        protected Bucket() {
        }

        public Item GetItem(string key) {
            Item item = Items.SingleOrDefault((it) => it.Key == key.ToLowerInvariant());
            if (item == null) {
                throw new ItemNotFoundException($"Item: {key}, Bucket: {Name}");
            }

            return item;
        }

        public void AddItem(string key, string value) {
            if (Items.Any((it) => it.Key == key.ToLowerInvariant())) {
                throw new ItemAlreadyExistsException($"Item: {key}, Bucket: {Name}");
            }

            _items.Add(new Item(key, value));
        }

        public void RemoveItem(string key) {
            _items.Remove(GetItem(key));
        }

    }

}
