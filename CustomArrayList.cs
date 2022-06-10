using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArrayList
{
    public class CustomArrayList 
    {
        private Object[] _items;
        private int _size;
        private int _version;
        private const int _defaultCapacity = 4;
        private static readonly Object[] emptyArray = new object[0];
        public CustomArrayList()
        {
            _items = emptyArray;
        }
        public CustomArrayList(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException();
            if (capacity == 0)
                _items = emptyArray;
            else
                _items = new Object[capacity];
        }
        public virtual int Add(Object value)
        {
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            _items[_size] = value;
            _version++;
            return _size++;
        }
        public void Insert(int index, object item)
        {
            if ((uint)index > (uint)_size)
            {
                throw new IndexOutOfRangeException();
            }
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }

            _items[index] = item;
            _size++;
        }
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if ((uint)newCapacity > 0X7FEFFFFF) newCapacity = 0X7FEFFFFF;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }
        public virtual int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        Object[] newItems = new Object[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = new Object[_defaultCapacity];
                    }
                }
            }
        }
        public virtual int Count
        {
            get
            {
                return _size;
            }
        }
        public virtual Object this[int index]
        {
            get
            {
                if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException();
                _items[index] = value;
                _version++;
            }
        }
        public void Clear()
        {
            _items = emptyArray;
        }
        public override string ToString()
        {
            return $"Count = {Count}";
        }
        public bool Contains(object element)
        {
            foreach (var item in _items)
            {
                if (Equals(element, item)) return true;
            }
            return false;
        }
        public int IndexOf(object item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }
        public int IndexOf(object item, int index)
        {
            if (index > _size)
                throw new ArgumentOutOfRangeException();
            return Array.IndexOf(_items, item, index, _size - index);
        }
        public int IndexOf(object item, int index, int count)
        {
            if (index > _size)
                throw new ArgumentOutOfRangeException();
            if (count < 0 || index > _size - count)
                throw new ArgumentOutOfRangeException();
            return Array.IndexOf(_items, item, index, count);
        }
        public int LastIndexOf(object item)
        {
            if (_size == 0)
            {
                return -1;
            }
            else
            {
                return LastIndexOf(item, _size - 1, _size);
            }
        }
        public int LastIndexOf(object item, int index)
        {
            if (index >= _size)
                throw new ArgumentOutOfRangeException();
            return LastIndexOf(item, index, index + 1);
        }
        public int LastIndexOf(object item, int index, int count)
        {
            if ((Count != 0) && (index < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            if ((Count != 0) && (count < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_size == 0)
            {
                return -1;
            }
            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (count > index + 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Array.LastIndexOf(_items, item, index, count);
        }
        public bool Remove(object item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                throw new ArgumentOutOfRangeException();
            }
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default(int);
            _version++;
        }
        public void RemoveRange(int index, int count)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_size - index < count)
                throw new ArgumentOutOfRangeException();
            if (count > 0)
            {
                int i = _size;
                _size -= count;
                if (index < _size)
                {
                    Array.Copy(_items, index + count, _items, index, _size - index);
                }
                Array.Clear(_items, _size, count);
                _version++;
            }
        }
        public void Reverse()
        {
            Reverse(0, Count);
        }
        public void Reverse(int index, int count)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_size - index < count)
                throw new ArgumentOutOfRangeException();
            Array.Reverse(_items, index, count);
            _version++;
        }
        public void CopyTo(object[] array)
        {
            CopyTo(array, 0);
        }
        public void CopyTo(object[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }
        public void CopyTo(int index, object[] array, int arrayIndex, int count)
        {
            if (_size - index < count)
            {
                throw new ArgumentException();
            }
            Array.Copy(_items, index, array, arrayIndex, count);
        }
      
        
    }
}
