using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConceptMeta.Collections
{
    /// <summary>
    /// An indexed list of items providing fast lookup. Duplicates are tolerated but are detected.
    /// </summary>
    /// <typeparam name="T">The type of each item in the dictionary</typeparam>
    public class IndexedSet<T> : IEnumerable<T>, IQueryable<T>, IList<T>
    {
        #region Private variables

        /// <summary>
        /// The dictionary that stores items
        /// </summary>
        private Dictionary<string, List<T>> dictionary = new Dictionary<string, List<T>>();

        /// <summary>
        /// The list that stores items
        /// </summary>
        private List<T> list = new List<T>();

        /// <summary>
        /// The list that stores keys in the same order
        /// </summary>
        private IList<string> keysList = new List<string>();

        /// <summary>
        /// The function that is used to determine the key for a given item
        /// </summary>
        private readonly Func<T, string> keyFunction = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Returns a new IndexedSet, to store a set of items of the specified type
        /// </summary>
        /// <param name="keyFunction">The function that is used to determine the key for a given item</param>
        public IndexedSet(Func<T, string> keyFunction)
        {
            this.keyFunction = keyFunction;
        }
        #endregion

        #region Properties
        public int Count
        {
            get { return list.Count; }
        }

        public bool HasDuplicates
        {
            get { return (list.Count > dictionary.Count); }
        }

        public Func<T, string> KeyFunction
        {
            get { return keyFunction; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified item to the dictionary
        /// </summary>
        /// <param name="item">The item to be added to the dictionary</param>
        public void Add(T item)
        {
            string key = GetKeyForItem(item);

            // add the item to the dictionary
            if (dictionary.ContainsKey(key) == false)
            {
                dictionary.Add(key, new List<T>());
            }
            dictionary[key].Add(item);

            // add the item to the list
            list.Add(item);

            // add the key to the list of keys
            keysList.Add(key);
        }

        /// <summary>
        /// Adds the specified item to the dictionary
        /// </summary>
        /// <param name="item">The item to be added to the dictionary</param>
        public void AddIfNotExists(T item)
        {
            string key = GetKeyForItem(item);

            if (dictionary.ContainsKey(key) == false)
            {
                // create a new entry in the dictionary of key -> List mappings
                dictionary.Add(key, new List<T>());

                // add the item to the list of items for the key
                dictionary[key].Add(item);

                // add the item to the list
                list.Add(item);

                // add the key to the list of keys
                keysList.Add(key);
            }
        }

        /// <summary>
        /// Removes the specified item
        /// </summary>
        /// <param name="item">The item to be removed</param>
        /// <returns>Boolean reflecting success</returns>
        public bool Remove(T item)
        {
            string key = GetKeyForItem(item);
            // remove it from the list
            if (list.Remove(item))
            {
                // removed it from the list successfully...

                // ... now remove the appropriate key from the list of keys
                keysList.Remove(key);

                // ... and remove the item from the dictionary
                if (dictionary[key].Count > 1)
                {
                    dictionary[key].Remove(item);
                }
                else
                {
                    dictionary.Remove(key);
                }

                // removed it completely
                return true;
            }
            else
            {
                // failed to remove it
                return false;
            }
        }

        /// <summary>
        /// Gets the item that is identified by the specified key
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns>the item</returns>
        public T GetItem(string key)
        {
            if (dictionary.ContainsKey(key) == false)
            {
                throw new ArgumentException("No items were found with the key \"" + key + "\"", "key");
            }
            else if (dictionary[key].Count == 0)
            {
                throw new ArgumentException("No items were found with the key \"" + key + "\"", "key");
            }
            else if (dictionary[key].Count > 1)
            {
                throw new ArgumentException("More than one item was found with the key \"" + key + "\"", "key");
            }
            else
            {
                return dictionary[key][0];
            }
        }

        /// <summary>
        /// Determines whether the collection contains an item with the specified key
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns>true if found, else false</returns>
        public bool ContainsKey(string key)
        {
            return (dictionary.ContainsKey(key));
        }

        /// <summary>
        /// Determines the key value for a given item
        /// </summary>
        /// <param name="item">the item</param>
        /// <returns>the key</returns>
        public string GetKeyForItem(T item)
        {
            string result = keyFunction(item);
            result = (result ?? "");
            return (result);
        }

        /// <summary>
        /// Gets the index of the specified item within the list
        /// </summary>
        /// <param name="item">the item</param>
        /// <returns>the index</returns>
        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        /// <summary>
        /// Inserts the specified item at the specified position within the list
        /// </summary>
        /// <param name="index">position</param>
        /// <param name="item">the item</param>
        public void Insert(int index, T item)
        {
            string key = GetKeyForItem(item);

            // add the item to the dictionary
            if (dictionary.ContainsKey(key) == false)
            {
                dictionary.Add(key, new List<T>());
            }
            dictionary[key].Add(item);

            // add the item to the list
            list.Insert(index, item);

            // add the key to the list of keys
            keysList.Insert(index, key);
        }

        /// <summary>
        /// Indexer - returns the item at the specified position
        /// </summary>
        /// <param name="index">position</param>
        /// <returns>the item at the specified position</returns>
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                // get details of the old item - i.e. the item being replaced
                T oldItem = list[index];
                string oldKey = keysList[index];

                // remove the old item from the dictionary
                if (dictionary[oldKey].Count > 1)
                {
                    dictionary[oldKey].Remove(oldItem);
                }
                else
                {
                    dictionary.Remove(oldKey);
                }

                // get details of the new item - i.e. the replacement item
                T item = value;
                string key = GetKeyForItem(item);

                // add the new item to the dictionary
                if (dictionary.ContainsKey(key) == false)
                {
                    dictionary.Add(key, new List<T>());
                }
                dictionary[key].Add(item);

                // replace the contents at the specified index
                list[index] = item;
                keysList[index] = key;
            }
        }

        /// <summary>
        /// Updates the index to reflect a change to the key of the specified item
        /// </summary>
        /// <param name="item">The item that has changed</param>
        public void UpdateKeyForChangedItem(T item)
        {
            // get details of the changed item
            T oldItem = item;
            int index = this.IndexOf(oldItem);
            string oldKey = keysList[index];

            // remove the old item from the dictionary
            if (dictionary[oldKey].Count > 1)
            {
                dictionary[oldKey].Remove(oldItem);
            }
            else
            {
                dictionary.Remove(oldKey);
            }

            // get details of the new item - i.e. the replacement item
            string key = GetKeyForItem(item);

            // add the new item to the dictionary
            if (dictionary.ContainsKey(key) == false)
            {
                dictionary.Add(key, new List<T>());
            }
            dictionary[key].Add(item);

            // refresh the contents at the specified index
            keysList[index] = key;
        }

        public IList<T> GetDuplicateItems()
        {
            IList<T> result = new List<T>();
            foreach (List<T> list in dictionary.Values)
            {
                if (list.Count > 1)
                {
                    foreach (T value in list)
                    {
                        result.Add(value);
                    }
                }
            }
            return result;
        }

        public Dictionary<string, List<T>> GetDictionaryOfListsClone()
        {
            Dictionary<string, List<T>> clone = new Dictionary<string, List<T>>();
            foreach (KeyValuePair<string, List<T>> pair in dictionary)
            {
                List<T> list = new List<T>();
                foreach (T item in pair.Value)
                {
                    list.Add(item);
                }
                clone.Add(pair.Key, list);
            }
            return clone;
        }
        public Dictionary<string, T> GetDictionaryOfFirstItemsClone()
        {
            Dictionary<string, T> clone = new Dictionary<string, T>();
            foreach (KeyValuePair<string, List<T>> pair in dictionary)
            {
                clone.Add(pair.Key, pair.Value.FirstOrDefault());
            }
            return clone;
        }
        #endregion

        #region Sort methods (exposing methods of the underlying list)
        private void RebuildDictionaryAndKeysList()
        {
            // tear down the Dictionary and KeysList
            dictionary = new Dictionary<string, List<T>>();
            keysList = new List<string>();

            // and repopulate it
            foreach (T item in list)
            {
                string key = GetKeyForItem(item);

                // add the item to the dictionary
                if (dictionary.ContainsKey(key) == false)
                {
                    dictionary.Add(key, new List<T>());
                }
                dictionary[key].Add(item);

                // add the key to the list of keys
                keysList.Add(key);
            }
        }
        public void Sort()
        {
            list.Sort();
            RebuildDictionaryAndKeysList();
        }
        public void Sort(Comparison<T> comparison)
        {
            list.Sort(comparison);
            RebuildDictionaryAndKeysList();
        }
        public void Sort(IComparer<T> comparer)
        {
            list.Sort(comparer);
            RebuildDictionaryAndKeysList();
        }
        public void Sort(int index, int count, IComparer<T> comparer)
        {
            list.Sort(index, count, comparer);
            RebuildDictionaryAndKeysList();
        }
        #endregion

        #region Implementation of IEnumerable<T>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (list.AsEnumerable<T>().GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (list.GetEnumerator());
        }
        #endregion

        #region Implementation of IQueryable<T>
        Expression IQueryable.Expression
        {
            get
            {
                return (list.AsQueryable().Expression);
            }
        }

        Type IQueryable.ElementType
        {
            get
            {
                return (list.AsQueryable().ElementType);
            }
        }

        IQueryProvider IQueryable.Provider
        {
            get
            {
                return (list.AsQueryable().Provider);
            }
        }
        #endregion

        #region Implementation of IList<T>

        int IList<T>.IndexOf(T item)
        {
            return this.IndexOf(item);
        }

        void IList<T>.RemoveAt(int index)
        {
            T itemToRemove = list[index];
            this.Remove(itemToRemove);
        }

        #endregion

        #region Implementation of ICollection
        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        void ICollection<T>.Clear()
        {
            dictionary.Clear();
            list.Clear();
            keysList.Clear();
        }

        bool ICollection<T>.Contains(T item)
        {
            // first try to find it using a fast lookup
            string key = GetKeyForItem(item);
            if (dictionary[key].Contains(item))
            {
                return true;
            }
            else
            {
                // not found - try a full search
                return list.Contains(item);
            }
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }
        #endregion
    }
}