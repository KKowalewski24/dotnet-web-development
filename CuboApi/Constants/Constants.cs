﻿namespace CuboApi.Constants {

    public static class Constants {

        /*Base*/
        public const string SLASH = "/";
        public const string CONTROLLER = "[controller]";
        public const string API = "api";
        public const string BASE_PATH_API_CONTROLLER = API + SLASH + CONTROLLER;

        /*Bucket Controller*/
        public const string PARAM_NAME = "{name}";

        /*Item Controller*/
        public const string BUCKET = "bucket";
        public const string ITEM = "item";
        public const string PARAM_BUCKET_NAME = "{bucketName}";
        public const string PARAM_KEY = "{key}";
        public const string BASE_PATH_ITEM_CONTROLLER =
            API + SLASH + BUCKET + SLASH + PARAM_BUCKET_NAME + SLASH + ITEM;

    }

}
