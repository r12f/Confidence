using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Confidence.UnitTests
{
    public class CollectionValidationTests
    {
        [Fact]
        public void CollectionIsEmptyCanBeValidated()
        {
            this.RunCollectionIsEmptyTest<List<int>, int>();
            this.RunCollectionIsEmptyTest<LinkedList<int>, int>();
            this.RunCollectionIsEmptyTest<HashSet<int>, int>();
            this.RunCollectionIsEmptyTest<SortedSet<int>, int>();
            this.RunCollectionIsEmptyTest<Dictionary<int, int>, KeyValuePair<int, int>>();
            this.RunCollectionIsEmptyTest<SortedDictionary<int, int>, KeyValuePair<int, int>>();
        }

        [Fact]
        public void CollectionCountCanBeValidated()
        {
            this.RunCollectionCountTest<List<int>, int>();
            this.RunCollectionCountTest<LinkedList<int>, int>();
            this.RunCollectionCountTest<HashSet<int>, int>();
            this.RunCollectionCountTest<SortedSet<int>, int>();
            this.RunCollectionCountTest<Dictionary<int, int>, KeyValuePair<int, int>>();
            this.RunCollectionCountTest<SortedDictionary<int, int>, KeyValuePair<int, int>>();
        }

        [Fact]
        public void CollectionContainsSpecificValueCanBeValidated()
        {
            this.RunCollectionContainsSpecificValueTest<List<int>, int>(1, 2);
            this.RunCollectionContainsSpecificValueTest<LinkedList<int>, int>(1, 2);
            this.RunCollectionContainsSpecificValueTest<HashSet<int>, int>(1, 2);
            this.RunCollectionContainsSpecificValueTest<SortedSet<int>, int>(1, 2);
        }

        [Fact]
        public void SpecificValueInCollectionCanBeValidated()
        {
            this.RunSpecificValueInCollectionTest<List<int>, int>(1, 2);
            this.RunSpecificValueInCollectionTest<LinkedList<int>, int>(1, 2);
            this.RunSpecificValueInCollectionTest<HashSet<int>, int>(1, 2);
            this.RunSpecificValueInCollectionTest<SortedSet<int>, int>(1, 2);
        }

        [Fact]
        public void CollectionHasAnyChildMatchesCanBeValidated()
        {
            this.RunCollectionAnyTest<List<int>, int>(1, 2);
            this.RunCollectionAnyTest<LinkedList<int>, int>(1, 2);
            this.RunCollectionAnyTest<HashSet<int>, int>(1, 2);
            this.RunCollectionAnyTest<SortedSet<int>, int>(1, 2);
        }

        [Fact]
        public void CollectionHasAllChildMatchesCanBeValidated()
        {
            this.RunCollectionAllTest<List<int>, int>(1, 2);
            this.RunCollectionAllTest<LinkedList<int>, int>(1, 2);
            this.RunCollectionAllTest<HashSet<int>, int>(1, 2);
            this.RunCollectionAllTest<SortedSet<int>, int>(1, 2);
        }

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

        private void RunCollectionIsEmptyTest<TCollection, TItem>()
            where TCollection : ICollection<TItem>, IEnumerable, new()
        {
            TCollection emptyCollection = new TCollection();
            Requires.Argument(emptyCollection, nameof(emptyCollection)).IsEmpty();
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).IsEmpty();
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).NotEmpty());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).NotEmpty());

            Requires.Argument(emptyCollection, nameof(emptyCollection)).IsEmptyByEnumeration();
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).IsEmptyByEnumeration();
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).NotEmptyByEnumeration());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).NotEmptyByEnumeration());

            TCollection nonEmptyCollection = new TCollection() { default(TItem) };
            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotEmpty();
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotEmpty();
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).IsEmpty());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).IsEmpty());

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotEmptyByEnumeration();
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotEmptyByEnumeration();
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).IsEmptyByEnumeration());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).IsEmptyByEnumeration());
        }

        private void RunCollectionCountTest<TCollection, TItem>()
            where TCollection : ICollection<TItem>, IEnumerable, new()
        {
            TCollection emptyCollection = new TCollection();
            Requires.Argument(emptyCollection, nameof(emptyCollection)).Count(0);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).Count(0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).Count(1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).Count(1));

            Requires.Argument(emptyCollection, nameof(emptyCollection)).NotCount(1);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).NotCount(1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).NotCount(0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).NotCount(0));

            Requires.Argument(emptyCollection, nameof(emptyCollection)).CountByEnumeration(0);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountByEnumeration(0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).CountByEnumeration(1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountByEnumeration(1));

            Requires.Argument(emptyCollection, nameof(emptyCollection)).NotCountByEnumeration(1);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).NotCountByEnumeration(1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).NotCountByEnumeration(0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).NotCountByEnumeration(0));

            TCollection nonEmptyCollection = new TCollection() { default(TItem) };
            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).Count(1);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).Count(1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).Count(0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).Count(0));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotCount(0);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotCount(0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotCount(1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotCount(1));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountByEnumeration(1);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountByEnumeration(1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountByEnumeration(0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountByEnumeration(0));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotCountByEnumeration(0);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotCountByEnumeration(0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotCountByEnumeration(1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotCountByEnumeration(1));
        }

        private void RunCollectionContainsSpecificValueTest<TCollection, TItem>(TItem valueInCollection, TItem valueNotInCollection)
            where TCollection : ICollection<TItem>, new()
        {
            TCollection testCollection = new TCollection() { valueInCollection };
            Requires.Argument(testCollection, nameof(testCollection)).Contains(valueInCollection);
            Requires<InvalidOperationException>.Argument(testCollection, nameof(testCollection)).Contains(valueInCollection);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testCollection, nameof(testCollection)).Contains(valueNotInCollection));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testCollection, nameof(testCollection)).Contains(valueNotInCollection));

            Requires.Argument(testCollection, nameof(testCollection)).NotContains(valueNotInCollection);
            Requires<InvalidOperationException>.Argument(testCollection, nameof(testCollection)).NotContains(valueNotInCollection);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testCollection, nameof(testCollection)).NotContains(valueInCollection));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testCollection, nameof(testCollection)).NotContains(valueInCollection));
        }

        private void RunSpecificValueInCollectionTest<TCollection, TItem>(TItem valueInCollection, TItem valueNotInCollection)
            where TCollection : ICollection<TItem>, new()
        {
            TCollection testCollection = new TCollection() { valueInCollection };
            Requires.Argument(valueInCollection, nameof(valueInCollection)).In(testCollection);
            Requires<InvalidOperationException>.Argument(valueInCollection, nameof(valueInCollection)).In(testCollection);
            Assert.Throws<ArgumentException>(() => Requires.Argument(valueNotInCollection, nameof(valueNotInCollection)).In(testCollection));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(valueNotInCollection, nameof(valueNotInCollection)).In(testCollection));

            Requires.Argument(valueNotInCollection, nameof(valueNotInCollection)).NotIn(testCollection);
            Requires<InvalidOperationException>.Argument(valueNotInCollection, nameof(valueNotInCollection)).NotIn(testCollection);
            Assert.Throws<ArgumentException>(() => Requires.Argument(valueInCollection, nameof(valueInCollection)).NotIn(testCollection));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(valueInCollection, nameof(valueInCollection)).NotIn(testCollection));
        }

        private void RunCollectionAnyTest<TCollection, TItem>(TItem valueInCollection, TItem valueNotInCollection)
            where TCollection : ICollection<TItem>, new()
        {
            TCollection testCollection = new TCollection() { valueInCollection };
            Requires.Argument(testCollection, nameof(testCollection)).Any((TItem x) => x.Equals(valueInCollection));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testCollection, nameof(testCollection)).Any((TItem x) => x.Equals(valueNotInCollection)));

            Requires.Argument(testCollection, nameof(testCollection)).UntypedAny((x) => x.Equals(valueInCollection));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testCollection, nameof(testCollection)).UntypedAny((x) => x.Equals(valueNotInCollection)));
        }

        private void RunCollectionAllTest<TCollection, TItem>(TItem valueInCollection, TItem valueNotInCollection)
            where TCollection : ICollection<TItem>, new()
        {
            TCollection testCollection = new TCollection() { valueInCollection };
            Requires.Argument(testCollection, nameof(testCollection)).All((TItem x) => !x.Equals(valueNotInCollection));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testCollection, nameof(testCollection)).All((TItem x) => !x.Equals(valueInCollection)));

            Requires.Argument(testCollection, nameof(testCollection)).UntypedAll((x) => !x.Equals(valueNotInCollection));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testCollection, nameof(testCollection)).UntypedAll((x) => !x.Equals(valueInCollection)));
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
