using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace Confidence.UnitTests
{
    public class SetValidationTests
    {
        [Fact]
        public void HashSetCanBeValidated()
        {
            HashSet<int> testSet = new HashSet<int>() { 1, 2, 3 };
            HashSet<int> subset = new HashSet<int>() { 1, 2 };
            HashSet<int> superset = new HashSet<int>() { 1, 2, 3, 4 };
            HashSet<int> overlapSet = new HashSet<int>() { 2, 3, 4 };
            HashSet<int> nonOverlapSet = new HashSet<int>() { 4, 5, 6 };
            this.RunSetValidationTests<HashSet<int>, int>(testSet, subset, superset, overlapSet, nonOverlapSet);
        }

        [Fact]
        public void SortedSetCanBeValidated()
        {
            SortedSet<int> testSet = new SortedSet<int>() { 1, 2, 3 };
            SortedSet<int> subset = new SortedSet<int>() { 1, 2 };
            SortedSet<int> superset = new SortedSet<int>() { 1, 2, 3, 4 };
            SortedSet<int> overlapSet = new SortedSet<int>() { 2, 3, 4 };
            SortedSet<int> nonOverlapSet = new SortedSet<int>() { 4, 5, 6 };
            this.RunSetValidationTests<SortedSet<int>, int>(testSet, subset, superset, overlapSet, nonOverlapSet);
        }

        [Fact]
        public void ImmutableHashSetCanBeValidated()
        {
            ImmutableHashSet<int> testSet = ImmutableHashSet.Create(1, 2, 3);
            ImmutableHashSet<int> subset = ImmutableHashSet.Create(1, 2);
            ImmutableHashSet<int> superset = ImmutableHashSet.Create(1, 2, 3, 4);
            ImmutableHashSet<int> overlapSet = ImmutableHashSet.Create(2, 3, 4);
            ImmutableHashSet<int> nonOverlapSet = ImmutableHashSet.Create(4, 5, 6);
            this.RunSetValidationTests<ImmutableHashSet<int>, int>(testSet, subset, superset, overlapSet, nonOverlapSet);
        }

        [Fact]
        public void ImmutableSortedSetCanBeValidated()
        {
            ImmutableSortedSet<int> testSet = ImmutableSortedSet.Create(1, 2, 3);
            ImmutableSortedSet<int> subset = ImmutableSortedSet.Create(1, 2);
            ImmutableSortedSet<int> superset = ImmutableSortedSet.Create(1, 2, 3, 4);
            ImmutableSortedSet<int> overlapSet = ImmutableSortedSet.Create(2, 3, 4);
            ImmutableSortedSet<int> nonOverlapSet = ImmutableSortedSet.Create(4, 5, 6);
            this.RunSetValidationTests<ImmutableSortedSet<int>, int>(testSet, subset, superset, overlapSet, nonOverlapSet);
        }

        private void RunSetValidationTests<TSet, TItem>(TSet testSet, TSet subset, TSet superset, TSet overlapSet, TSet nonOverlapSet)
            where TSet : ISet<TItem>
        {
            // IsProperSubsetOf
            Requires.Argument(testSet, nameof(testSet)).IsProperSubsetOf(superset);
            Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).IsProperSubsetOf(superset);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).IsProperSubsetOf(testSet));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).IsProperSubsetOf(testSet));

            // NotProperSubsetOf
            Requires.Argument(testSet, nameof(testSet)).NotProperSubsetOf(testSet);
            Requires.Argument(testSet, nameof(testSet)).NotProperSubsetOf(subset);
            Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).NotProperSubsetOf(subset);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).NotProperSubsetOf(superset));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).NotProperSubsetOf(superset));

            // IsSubsetOf
            Requires.Argument(testSet, nameof(testSet)).IsSubsetOf(superset);
            Requires.Argument(testSet, nameof(testSet)).IsSubsetOf(testSet);
            Assert.Throws<ArgumentException>(() => Requires.Argument(superset, nameof(superset)).IsSubsetOf(testSet));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(superset, nameof(superset)).IsSubsetOf(testSet));

            // NotSubsetOf
            Requires.Argument(testSet, nameof(testSet)).NotSubsetOf(subset);
            Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).NotSubsetOf(subset);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).NotSubsetOf(testSet));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).NotSubsetOf(superset));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).NotSubsetOf(superset));

            // IsProperSupersetOf
            Requires.Argument(testSet, nameof(testSet)).IsProperSupersetOf(subset);
            Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).IsProperSupersetOf(subset);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).IsProperSupersetOf(testSet));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).IsProperSupersetOf(testSet));

            // NotProperSupersetOf
            Requires.Argument(testSet, nameof(testSet)).NotProperSupersetOf(testSet);
            Requires.Argument(testSet, nameof(testSet)).NotProperSupersetOf(superset);
            Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).NotProperSupersetOf(superset);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).NotProperSupersetOf(subset));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).NotProperSupersetOf(subset));

            // IsSupersetOf
            Requires.Argument(testSet, nameof(testSet)).IsSupersetOf(subset);
            Requires.Argument(testSet, nameof(testSet)).IsSupersetOf(testSet);
            Assert.Throws<ArgumentException>(() => Requires.Argument(subset, nameof(subset)).IsSupersetOf(testSet));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(subset, nameof(subset)).IsSupersetOf(testSet));

            // NotSupersetOf
            Requires.Argument(testSet, nameof(testSet)).NotSupersetOf(superset);
            Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).NotSupersetOf(superset);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).NotSupersetOf(testSet));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).NotSupersetOf(subset));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).NotSupersetOf(subset));

            // Overlaps
            Requires.Argument(testSet, nameof(testSet)).Overlaps(subset);
            Requires.Argument(testSet, nameof(testSet)).Overlaps(testSet);
            Requires.Argument(testSet, nameof(testSet)).Overlaps(superset);
            Requires.Argument(testSet, nameof(testSet)).Overlaps(overlapSet);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).Overlaps(nonOverlapSet));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).Overlaps(nonOverlapSet));

            // NotOverlaps
            Requires.Argument(testSet, nameof(testSet)).NotOverlaps(nonOverlapSet);
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).NotOverlaps(subset));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).NotOverlaps(testSet));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).NotOverlaps(superset));
            Assert.Throws<ArgumentException>(() => Requires.Argument(testSet, nameof(testSet)).NotOverlaps(overlapSet));
            Assert.Throws<InvalidOperationException>(() => Requires<InvalidOperationException>.Argument(testSet, nameof(testSet)).NotOverlaps(testSet));
        }
    }
}