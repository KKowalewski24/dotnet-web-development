using System;
using System.Runtime.Serialization;

namespace CuboCore.Exceptions.Buckets {

    public class BucketAlreadyExistsException : AlreadyExistsException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public BucketAlreadyExistsException() {
        }

        protected BucketAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public BucketAlreadyExistsException(string message)
            : base(message) {
        }

        public BucketAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
