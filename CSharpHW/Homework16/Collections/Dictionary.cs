using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class VladDictionary<TKey, TValue>
    {
        private class _Item<T, U>
        {
            public T Key { get; set; }
            public U Value { get; set; }

            public override bool Equals(object obj)
            {
                _Item<T, U> item = obj as _Item<T, U>;
                if (item == null)
                    return false;
                return Key.Equals(item.Key);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        private HashSet<_Item<TKey, TValue>> _Items = new HashSet<_Item<TKey, TValue>>();

        public void Add(TKey key, TValue value)
        {
            var newItem = new _Item<TKey, TValue>();
            newItem.Key = key;
            newItem.Value = value;
            _Items.Add(newItem);
        }

        public TValue this[TKey key]
        {
            get
            {
                var keyItem = new _Item<TKey, TValue>();
                keyItem.Key = key;
                var item = _Items.First( (i) => i.Equals(keyItem));
                return item.Value;
            }
            set
            {
                var keyItem = new _Item<TKey, TValue>();
                keyItem.Key = key;
                var item = _Items.First((i) => i.Equals(keyItem));
                item.Value = value;
            }
        }

    }
}
