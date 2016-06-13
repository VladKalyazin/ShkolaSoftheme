using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class VladStack<T>
    {
        private class _Item<U>
        {
            public _Item<U> NextItem { get; set; }

            public U Value { get; set; }
        }

        private _Item<T> _End;

        public void Push(T obj)
        {
            var newItem = new _Item<T>();
            newItem.Value = obj;

            if (_End == null)
            {
                _End = newItem;
            }
            else
            {
                newItem.NextItem = _End;
                _End = newItem;
            }
        }

        public T Pop()
        {
            if (_End == null)
                throw new ArgumentNullException("Stack doesn't contain any item.");
            T value = _End.Value;
            _End = _End.NextItem;
            return value;
        }

        public T Peek() => _End.Value;
    }
}
