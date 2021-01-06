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

        /*------------------------ METHODS REGION ------------------------*/
        protected Bucket() {
        }

        public Bucket(string name) {
            Name = name;
            CreatedAt = DateTime.Now;
        }

        public Item GetItem(string key) {
            Item item = _items.SingleOrDefault((it) => it.Key == key.ToLowerInvariant());
            if (item == null) {
                throw new ItemNotFoundException($"Item: {key}, Bucket: {Name}");
            }

            return item;
        }

        public void AddItem(string key, string value) {
            if (_items.Any((it) => it.Key == key.ToLowerInvariant())) {
                throw new ItemAlreadyExistsException($"Item: {key}, Bucket: {Name}");
            }

            _items.Add(new Item(key, value));
        }

        public void RemoveItem(string key) {
            _items.Remove(GetItem(key));
        }

        protected bool Equals(Bucket other) {
            return base.Equals(other) && Equals(_items, other._items) && Name == other.Name &&
                   CreatedAt.Equals(other.CreatedAt);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }

            if (ReferenceEquals(this, obj)) {
                return true;
            }

            if (obj.GetType() != this.GetType()) {
                return false;
            }

            return Equals((Bucket)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (_items != null ? _items.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Name)}: {Name}, " +
                   $"{nameof(CreatedAt)}: {CreatedAt}, " +
                   $"{nameof(_items)}: {_items}";
        }

    }

}
