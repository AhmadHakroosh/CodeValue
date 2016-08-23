using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class MultiDictionary<K, V> : IMultiDictionary<K, V> where K : class where V : new()
    {
        Dictionary<K, LinkedList<V>> _dic = new Dictionary<K, LinkedList<V>>();
        bool _Checked = false;

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        public void Clear() => _dic.Clear();
        public bool Contains(K key, V value) => _dic.ContainsKey(key) && _dic[key].Contains(value);
        public bool ContainsKey(K key) => _dic.ContainsKey(key);
        public void CreateNewValue(K key) => Add(key, new V());
        public bool Remove(K key) => _dic.Remove(key);

        public int Count
        {
            get
            {
                return _dic.Sum(v => v.Value.Count);
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                return _dic.Keys;
            }
        }

        public ICollection<V> Values
        {
            get
            {
                var result = (ICollection<V>)_dic.Select(v => v.Value);
                return result;
            }
        }

        public void Add(K key, V value)
        {
            if (!_Checked)
            {
                if (Attribute.GetCustomAttribute(key.GetType(), typeof(KeyAttribute)) == null)
                {
                    throw new ArgumentException("Key must be with 'KeyAttribute'.");
                }
            }

            if (!_dic.ContainsKey(key))
                _dic.Add(key, new LinkedList<V>());

            _dic[key].AddLast(value);
        }
        
        public bool Remove(K key, V value)
        {
            var result = false;

            if (_dic.ContainsKey(key))
                result = _dic[key].Remove(value);

            return result;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var key in _dic)
            {
                foreach (var sub in key.Value)
                {
                    yield return new KeyValuePair<K, V>(key.Key, sub);
                }
            }
        }
    }
}
