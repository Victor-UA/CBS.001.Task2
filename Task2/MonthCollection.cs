using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MonthCollection: ICollection<Month>
    {
        const uint DEFAULT_MONTHS_QUANTITY = 12;
        Month[] _months;

        public MonthCollection()
        {
            Clear();
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public Month this[uint index]
        {
            get
            {
                if (index < Count )
                {
                    return _months[index];
                }
                else
                {
                    throw new IndexOutOfRangeException($"Index needs to be in range [0, {Count - 1}]");
                }
            }
        }

        public void Add(Month item)
        {
            if (!IsReadOnly)
            {
                if (++Count > _months.Length)
                {
                    ArrayExpand(ref _months);
                }
                _months[Count - 1] = item;
            }
        }
        
        private void Array(ref Month[] array)
        {
            int arrayNewLength = (int)(array.Length * 1.5) + 1;
            Month[] arrayNew = new Month[arrayNewLength];
            array.CopyTo(arrayNew, 0);
            array = arrayNew;
        }

        public void Clear()
        {
            _months = new Month[DEFAULT_MONTHS_QUANTITY];
            Count = 0;
        }

        public bool Contains(Month item)
        {
            foreach (var month in _months)
            {
                if (item.Equals(month))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Month[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < Count; i++)
            {
                array[i - arrayIndex] = _months[i];
            }
        }

        public bool Remove(Month item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_months[i].Equals(item))
                {
                    Count--;
                    for (int j = i; j < Count; j++)
                    {
                        _months[j] = _months[j + 1];
                    }
                    ArrayReduce(ref _months, Count);
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<Month> GetEnumerator()
        {
            return (IEnumerator<Month>) _months.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _months.GetEnumerator();
        }


        public IEnumerable<Month> GetMonthsByNumber(uint number)
        {
            for (int i = 0; i < Count; i++)
            {
                var currentItem = _months[i];
                if (currentItem.Number == number)
                {
                    yield return currentItem;
                }
            }
        }

        public IEnumerable<Month> GetMonthsByDaysQuantity(uint quantity)
        {
            for (int i = 0; i < Count; i++)
            {
                var currentItem = _months[i];
                if (currentItem.DaysQuantity == quantity)
                {
                    yield return currentItem;
                }
            }
        }

        private void ArrayExpand(ref Month[] array)
        {
            int arrayNewLength = (int)(array.Length * 1.5) + 1;
            Month[] arrayNew = new Month[arrayNewLength];
            array.CopyTo(arrayNew, 0);
            array = arrayNew;
        }

        private void ArrayReduce(ref Month[] array, int count)
        {
            int arrayNewLength;
            int arrayNewLengthNext = array.Length;
            do
            {
                arrayNewLength = arrayNewLengthNext;
                arrayNewLengthNext = (int)(arrayNewLength / 1.5) - 1;
            } while (arrayNewLengthNext >= count);

            Month[] arrayNew = new Month[arrayNewLength];
            for (int i = 0; i < count; i++)
            {
                arrayNew[i] = array[i];
            }
            array = arrayNew;
        }

    }
}
