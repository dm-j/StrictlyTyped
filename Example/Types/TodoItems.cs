using StrictlyTyped;

namespace Example
{
    public static partial class TodoItems
    {
        [StrictGuid]
        public partial record struct Id;

        [StrictString]
        public partial record struct Name;

        [StrictBool]
        public partial record struct IsComplete;

        [StrictString]
        public partial record struct Secret;
    }
}
