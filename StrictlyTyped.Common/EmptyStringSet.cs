using System.Collections;

namespace StrictlyTyped
{
    public class EmptyReadOnlyStringSet : IReadOnlySet<string>
    {
        private EmptyReadOnlyStringSet() { }
        
        public IEnumerator<string> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => 0;

        public static EmptyReadOnlyStringSet Instance { get; } = new();

        public bool Contains(string item) => false;

        public bool IsProperSubsetOf(IEnumerable<string> other) => false;

        public bool IsProperSupersetOf(IEnumerable<string> other) => false;

        public bool IsSubsetOf(IEnumerable<string> other) => false;

        public bool IsSupersetOf(IEnumerable<string> other) => false;

        public bool Overlaps(IEnumerable<string> other) => false;

        public bool SetEquals(IEnumerable<string> other) => false;
    }
}
