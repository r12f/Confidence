using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace Confidence.UnitTests
{
    public class CollectionValidationTests
    {
        [Fact]
        public void CollectionIsEmptyCanBeValidated()
        {
            this.RunCollectionIsEmptyTest<List<int>, int>(new List<int>(), new List<int> { 0 });
            this.RunCollectionIsEmptyTest<LinkedList<int>, int>(new LinkedList<int>(), new LinkedList<int>(new[] { 0 }));
            this.RunCollectionIsEmptyTest<HashSet<int>, int>(new HashSet<int>(), new HashSet<int>() { 0 });
            this.RunCollectionIsEmptyTest<SortedSet<int>, int>(new SortedSet<int>(), new SortedSet<int>() { 0 });
            this.RunCollectionIsEmptyTest<Dictionary<int, int>, KeyValuePair<int, int>>(new Dictionary<int, int>(), new Dictionary<int, int>() { { 0, 0 } });
            this.RunCollectionIsEmptyTest<SortedDictionary<int, int>, KeyValuePair<int, int>>(new SortedDictionary<int, int>(), new SortedDictionary<int, int>() { { 0, 0 } });
            this.RunCollectionIsEmptyTest<ImmutableList<int>, int>(ImmutableList.Create<int>(), ImmutableList.Create(0));
            this.RunCollectionIsEmptyTest<ImmutableHashSet<int>, int>(ImmutableHashSet.Create<int>(), ImmutableHashSet.Create(0));
            this.RunCollectionIsEmptyTest<ImmutableSortedSet<int>, int>(ImmutableSortedSet.Create<int>(), ImmutableSortedSet.Create(0));
        }

        [Fact]
        public void CollectionCountCanBeValidated()
        {
            this.RunCollectionCountTest<List<int>, int>(new List<int>(), new List<int> { 0 });
            this.RunCollectionCountTest<LinkedList<int>, int>(new LinkedList<int>(), new LinkedList<int>(new[] { 0 }));
            this.RunCollectionCountTest<HashSet<int>, int>(new HashSet<int>(), new HashSet<int>() { 0 });
            this.RunCollectionCountTest<SortedSet<int>, int>(new SortedSet<int>(), new SortedSet<int>() { 0 });
            this.RunCollectionCountTest<Dictionary<int, int>, KeyValuePair<int, int>>(new Dictionary<int, int>(), new Dictionary<int, int>() { { 0, 0 } });
            this.RunCollectionCountTest<SortedDictionary<int, int>, KeyValuePair<int, int>>(new SortedDictionary<int, int>(), new SortedDictionary<int, int>() { { 0, 0 } });
            this.RunCollectionCountTest<ImmutableList<int>, int>(ImmutableList.Create<int>(), ImmutableList.Create(0));
            this.RunCollectionCountTest<ImmutableHashSet<int>, int>(ImmutableHashSet.Create<int>(), ImmutableHashSet.Create(0));
            this.RunCollectionCountTest<ImmutableSortedSet<int>, int>(ImmutableSortedSet.Create<int>(), ImmutableSortedSet.Create(0));
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

        private void RunCollectionIsEmptyTest<TCollection, TItem>(TCollection emptyCollection, TCollection nonEmptyCollection)
            where TCollection : ICollection<TItem>, IEnumerable
        {
            // IsEmpty
            Requires.Argument(emptyCollection, nameof(emptyCollection)).IsEmpty();
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).IsEmpty();
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).IsEmpty());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).IsEmpty());

            // IsEmptyByEnumeration
            Requires.Argument(emptyCollection, nameof(emptyCollection)).IsEmptyByEnumeration();
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).IsEmptyByEnumeration();
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).IsEmptyByEnumeration());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).IsEmptyByEnumeration());

            // NotEmpty
            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotEmpty();
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotEmpty();
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).NotEmpty());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).NotEmpty());

            // NotEmptyByEnumeration
            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotEmptyByEnumeration();
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).NotEmptyByEnumeration();
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).NotEmptyByEnumeration());
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).NotEmptyByEnumeration());
        }

        private void RunCollectionCountTest<TCollection, TItem>(TCollection emptyCollection, TCollection nonEmptyCollection)
            where TCollection : ICollection<TItem>, IEnumerable
        {
            // Count
            Requires.Argument(emptyCollection, nameof(emptyCollection)).CountIs(0);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountIs(0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).CountIs(1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountIs(1));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIs(1);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIs(1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIs(0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIs(0));

            // NotCount
            Requires.Argument(emptyCollection, nameof(emptyCollection)).CountNot(1);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountNot(1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).CountNot(0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountNot(0));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNot(0);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNot(0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNot(1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNot(1));

            // CountByEnumeration
            Requires.Argument(emptyCollection, nameof(emptyCollection)).CountIsByEnumeration(0);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountIsByEnumeration(0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).CountIsByEnumeration(1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountIsByEnumeration(1));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsByEnumeration(1);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsByEnumeration(1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsByEnumeration(0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsByEnumeration(0));

            // NotCountByEnumeration
            Requires.Argument(emptyCollection, nameof(emptyCollection)).CountNotByEnumeration(1);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountNotByEnumeration(1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).CountNotByEnumeration(0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountNotByEnumeration(0));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotByEnumeration(0);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotByEnumeration(0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotByEnumeration(1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotByEnumeration(1));

            // CountIsInRange
            Requires.Argument(emptyCollection, nameof(emptyCollection)).CountIsInRange(0, 0);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountIsInRange(0, 1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).CountIsInRange(1, 1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountIsInRange(1, 1));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsInRange(1, 1);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsInRange(1, 2);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsInRange(0, 0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsInRange(0, 0));

            // CountNotInRange
            Requires.Argument(emptyCollection, nameof(emptyCollection)).CountNotInRange(1, 1);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountNotInRange(1, 2);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).CountNotInRange(0, 0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountNotInRange(0, 1));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotInRange(0, 0);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotInRange(-1, 0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotInRange(1, 1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotInRange(1, 2));

            // CountIsInRangeByEnumeration
            Requires.Argument(emptyCollection, nameof(emptyCollection)).CountIsInRangeByEnumeration(0, 0);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountIsInRangeByEnumeration(0, 1);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).CountIsInRangeByEnumeration(1, 1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountIsInRangeByEnumeration(1, 1));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsInRangeByEnumeration(1, 1);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsInRangeByEnumeration(1, 2);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsInRangeByEnumeration(0, 0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountIsInRangeByEnumeration(0, 0));
            
            // CountNotInRangeByEnumeration
            Requires.Argument(emptyCollection, nameof(emptyCollection)).CountNotInRangeByEnumeration(1, 1);
            Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountNotInRangeByEnumeration(1, 2);
            Assert.Throws<ArgumentException>(() => Requires.Argument(emptyCollection, nameof(emptyCollection)).CountNotInRangeByEnumeration(0, 0));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(emptyCollection, nameof(emptyCollection)).CountNotInRangeByEnumeration(0, 1));

            Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotInRangeByEnumeration(0, 0);
            Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotInRangeByEnumeration(-1, 0);
            Assert.Throws<ArgumentException>(() => Requires.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotInRangeByEnumeration(1, 1));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(nonEmptyCollection, nameof(nonEmptyCollection)).CountNotInRangeByEnumeration(1, 2));
        }

        private void RunCollectionContainsSpecificValueTest<TCollection, TItem>(TItem valueInCollection, TItem valueNotInCollection)
            where TCollection : ICollection<TItem>, new()
        {
            TCollection testCollection = new TCollection() { valueInCollection };
            Requires.Argument(testCollection, nameof(testCollection)).Contains(valueInCollection);
            Requires<InvalidOperationException>.Argument(testCollection, nameof(testCollection)).Contains(valueInCollection);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testCollection, nameof(testCollection)).Contains(valueNotInCollection));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testCollection, nameof(testCollection)).Contains(valueNotInCollection));

            Requires.Argument(testCollection, nameof(testCollection)).DoesNotContain(valueNotInCollection);
            Requires<InvalidOperationException>.Argument(testCollection, nameof(testCollection)).DoesNotContain(valueNotInCollection);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testCollection, nameof(testCollection)).DoesNotContain(valueInCollection));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testCollection, nameof(testCollection)).DoesNotContain(valueInCollection));
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
    }
}
