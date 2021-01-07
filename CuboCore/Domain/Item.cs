namespace CuboCore.Domain {

    public class Item : BaseEntity {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Key { get; private set; }
        public string Value { get; private set; }

        /*------------------------ METHODS REGION ------------------------*/
        protected Item() {
        }

        public Item(string key, string value) {
            Key = key;
            Value = value;
        }

        protected bool Equals(Item other) {
            return base.Equals(other) && Key == other.Key && Value == other.Value;
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

            return Equals((Item)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Key != null ? Key.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Key)}: {Key}, " +
                   $"{nameof(Value)}: {Value}";
        }

    }

}
