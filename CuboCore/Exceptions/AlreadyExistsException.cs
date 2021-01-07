using System;
using System.Runtime.Serialization;

namespace CuboCore.Exceptions {

    public class AlreadyExistsException : Exception {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public AlreadyExistsException() {
        }

        protected AlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public AlreadyExistsException(string message)
            : base(message) {
        }

        public AlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
