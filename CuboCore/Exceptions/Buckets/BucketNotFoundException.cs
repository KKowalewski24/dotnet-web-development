using System;
using System.Runtime.Serialization;

namespace CuboCore.Exceptions.Buckets {

    public class BucketNotFoundException : NotFoundException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public BucketNotFoundException() {
        }

        protected BucketNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public BucketNotFoundException(string message)
            : base(message) {
        }

        public BucketNotFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
