using System;
using System.Collections.Generic;
using Xunit;

namespace Confidence.UnitTests
{
    public class DictionaryValidationTests
    {
        [Fact]
        public void DictionaryContainsKeyCanBeValidated()
        {
            this.RunDictionaryContainsKeyTest<Dictionary<int, int>, int, int>(
                new[] { new KeyValuePair<int, int>(1, 2), new KeyValuePair<int, int>(3, 4) },
                1,
                5);

            this.RunDictionaryContainsKeyTest<SortedDictionary<int, int>, int, int>(
                new[] { new KeyValuePair<int, int>(1, 2), new KeyValuePair<int, int>(3, 4) },
                1,
                5);
        }

        private void RunDictionaryContainsKeyTest<TDictionary, TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> valuePairs, TKey keyInDictionary, TKey keyNotInDictionary)
            where TDictionary : IDictionary<TKey, TValue>, new()
        {
            TDictionary dictionary = new TDictionary();
            foreach (var valuePair in valuePairs)
            {
                dictionary.Add(valuePair);
            }

            Requires.Argument(dictionary, nameof(dictionary)).ContainsKey<TDictionary, TKey, TValue>(keyInDictionary);
            Requires<InvalidOperationException>.Argument(dictionary, nameof(dictionary)).ContainsKey<TDictionary, TKey, TValue>(keyInDictionary);
            Assert.Throws<ArgumentException>(() => Requires.Argument(dictionary, nameof(dictionary)).ContainsKey<TDictionary, TKey, TValue>(keyNotInDictionary));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(dictionary, nameof(dictionary)).ContainsKey<TDictionary, TKey, TValue>(keyNotInDictionary));

            Requires.Argument(dictionary, nameof(dictionary)).NotContainsKey<TDictionary, TKey, TValue>(keyNotInDictionary);
            Requires<InvalidOperationException>.Argument(dictionary, nameof(dictionary)).NotContainsKey<TDictionary, TKey, TValue>(keyNotInDictionary);
            Assert.Throws<ArgumentException>(() => Requires.Argument(dictionary, nameof(dictionary)).NotContainsKey<TDictionary, TKey, TValue>(keyInDictionary));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(dictionary, nameof(dictionary)).NotContainsKey<TDictionary, TKey, TValue>(keyInDictionary));
        }
    }
}

