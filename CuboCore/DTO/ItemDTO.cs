namespace CuboCore.DTO {

    public class ItemDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Key { get; set; }
        public string Value { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public ItemDTO() {
        }

        public ItemDTO(string key, string value) {
            Key = key;
            Value = value;
        }

    }

}
