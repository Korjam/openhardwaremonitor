
namespace OxyPlot.WindowsForms
{
    using System.Collections.Generic;

    public class HashSet<T>
    {

        private readonly Dictionary<T, object> set = new Dictionary<T, object>();

        public bool Add(T value)
        {
            if (set.ContainsKey(value))
                return true;

            set.Add(value, null);
            return false;
        }

        public bool Contains(T value)
        {
            return set.ContainsKey(value);
        }

        public void Clear()
        {
            set.Clear();
        }
    }
}
