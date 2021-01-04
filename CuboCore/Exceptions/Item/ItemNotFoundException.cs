using System;
using System.Runtime.Serialization;

namespace CuboCore.Exceptions.Item {

    public class ItemNotFoundException : NotFoundException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public ItemNotFoundException() {
        }

        protected ItemNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public ItemNotFoundException(string message)
            : base(message) {
        }

        public ItemNotFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
