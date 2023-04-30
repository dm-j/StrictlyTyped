using System.Collections;

namespace StrictlyTyped
{
    internal class EmptyStringSet : IReadOnlySet<string>
    {
        private EmptyStringSet() { }

        public static EmptyStringSet Instance { get; } = new();

        public int Count => 0;

        public bool Contains(string item) => 
            false;

        public IEnumerator<string> GetEnumerator() =>
            GetEnumerator();

        public bool IsProperSubsetOf(IEnumerable<string> other) =>
            false;

        public bool IsProperSupersetOf(IEnumerable<string> other) =>
            false;

        public bool IsSubsetOf(IEnumerable<string> other) =>
            false;

        public bool IsSupersetOf(IEnumerable<string> other) =>
            false;

        public bool Overlaps(IEnumerable<string> other) =>
            false;

        public bool SetEquals(IEnumerable<string> other) =>
            false;

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }
    }
}
