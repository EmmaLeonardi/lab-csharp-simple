namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {

        private readonly IDictionary<Tuple<TKey1, TKey2>, TValue> map=new Dictionary<Tuple<TKey1, TKey2>, TValue>();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements
        {
            get => map.Count();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => map[new Tuple<TKey1, TKey2>(key1, key2)];
            set => map[new Tuple<TKey1, TKey2>(key1, key2)] =value;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            IList<Tuple<TKey2, TValue>> list = new List<Tuple<TKey2, TValue>>();
            foreach(var elem in map)
            {
                if (elem.Key.Item1.Equals(key1))
                {
                    list.Add(new Tuple<TKey2, TValue>(elem.Key.Item2, elem.Value));
                }
            }

            return list;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            IList<Tuple<TKey1, TValue>> list = new List<Tuple<TKey1, TValue>>();
            foreach (var elem in map)
            {
                if (elem.Key.Item2.Equals(key2))
                {
                    list.Add(new Tuple<TKey1, TValue>(elem.Key.Item1, elem.Value));
                }
            }

            return list;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            IList<Tuple<TKey1, TKey2, TValue>> list = new List<Tuple<TKey1, TKey2, TValue>>();
            foreach (var elem in map)
            {
                list.Add(new Tuple<TKey1, TKey2, TValue>(elem.Key.Item1,elem.Key.Item2,elem.Value));
            }

            return list;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            Console.WriteLine("La mappa attuale"+map.ToString());
            foreach(var k1 in keys1)
            {
                foreach(var k2 in keys2){
                    map.Add(new Tuple<TKey1, TKey2>(k1, k2), generator.Invoke(k1, k2));
                }
            }

        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            if (other.GetElements().Equals(this.GetElements()))
            {
                return true;
            }
            else return false;
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            if(obj is IMap2D<TKey1, TKey2, TValue>)
            {
                return Equals((IMap2D<TKey1, TKey2, TValue>)obj);
            }
            return false;
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(map);
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            String s = "";
            foreach (var elem in map.Keys)
            {
                s += "["+elem.Item1.ToString()+", " + elem.Item2.ToString() + ": " + map[elem].ToString()+ " ]"+Environment.NewLine;
            }
            return s;
        }
    }
}
