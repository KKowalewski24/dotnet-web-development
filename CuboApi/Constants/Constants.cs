namespace CuboApi.Constants {

    public static class Constants {

        /*Base*/
        public const string SLASH = "/";
        public const string CONTROLLER = "[controller]";
        public const string API = "api";
        public const string BASE_PATH_API_CONTROLLER = API + SLASH + CONTROLLER;

        /*Bucket Controller*/
        public const string PARAM_NAME = "{name}";

        /*Item Controller*/
        public const string BUCKETS = "buckets";
        public const string ITEMS = "items";
        public const string PARAM_BUCKET_NAME = "{bucketName}";
        public const string PARAM_KEY = "{key}";
        public const string BASE_PATH_ITEM_CONTROLLER =
            API + SLASH + BUCKETS + SLASH + PARAM_BUCKET_NAME + SLASH + ITEMS;

    }

}
