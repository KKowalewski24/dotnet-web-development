using System;
using System.Runtime.Serialization;

namespace CuboCore.Exceptions.Items {

    public class ItemAlreadyExistsException : AlreadyExistsException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public ItemAlreadyExistsException() {
        }

        protected ItemAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public ItemAlreadyExistsException(string message)
            : base(message) {
        }

        public ItemAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
