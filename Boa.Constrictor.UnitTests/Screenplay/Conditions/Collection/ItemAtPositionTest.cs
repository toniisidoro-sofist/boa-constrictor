using Boa.Constrictor.Screenplay;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Boa.Constrictor.UnitTests.Screenplay
{
    [TestFixture]
    public class ItemAtPositionTest
    {
        #region Tests

        [Test]
        public void WhereTheItemAtPositionIsEqualToValue_WithItemAtPositionEqual_ShouldBeTrue()
        {
            int[] array = { 1, 2, 3 };
            IsAnEnumerable<int>.WhereTheItemAtPosition(0, IsEqualTo.Value(1)).Evaluate(array).Should().BeTrue();
        }

        [Test]
        public void WhereTheItemAtPositionIsEqualToValue_WithItemAtPositionNotEqual_ShouldBeFalse()
        {
            int[] array = { 1, 2, 3 };
            IsAnEnumerable<int>.WhereTheItemAtPosition(2, IsEqualTo.Value(2)).Evaluate(array).Should().BeFalse();
        }

        [Test]
        public void WhereTheItemAtPositionIsEqualToValue_WithNotExistentItemInPosition_ShouldThrowException()
        {
            int[] array = { 1, 2, 3 };
            Action act = () => IsAnEnumerable<int>.WhereTheItemAtPosition(3, IsEqualTo.Value(3)).Evaluate(array);
            act.Should().Throw<ScreenplayException>()
                 .WithMessage("The informed position is out of the range of the enumerable items!");
        }

        [Test]
        public void WhereTheItemAtPositionIsEqualToValue_WithNegativePosition_ShouldThrowException()
        {
            int[] array = { 1, 2, 3 };
            Action act = () => IsAnEnumerable<int>.WhereTheItemAtPosition(-1, IsEqualTo.Value(1)).Evaluate(array);
            act.Should().Throw<ScreenplayException>()
                 .WithMessage("The informed position is out of the range of the enumerable items!");
        }

        [Test]
        public void WhereTheItemAtPositionIsEqualToValue_WithJustOneItemAndNotExistentItemInPosition_ShouldThrowException()
        {
            int[] array = { 1 };
            Action act = () => IsAnEnumerable<int>.WhereTheItemAtPosition(1, IsEqualTo.Value(1)).Evaluate(array);
            act.Should().Throw<ScreenplayException>()
                 .WithMessage("The informed position is out of the range of the enumerable items!");
        }

        [Test]
        public void WhereTheItemAtPositionIsGreaterThanValue_WithItemAtPositionGreater_ShouldBeTrue()
        {
            int[] array = { 1, 2, 3 };
            IsAnEnumerable<int>.WhereTheItemAtPosition(0, IsGreaterThan.Value(0)).Evaluate(array).Should().BeTrue();
        }

        [Test]
        public void WhereTheItemAtPositionIsGreaterThanValue_WithItemAtPositionNotGreater_ShouldBeFalse()
        {
            int[] array = { 1, 2, 3 };
            IsAnEnumerable<int>.WhereTheItemAtPosition(1, IsGreaterThan.Value(2)).Evaluate(array).Should().BeFalse();
        }

        [Test]
        public void WhereTheItemAtPositionIsGreaterThanValue_WithNotExistentItemInPosition_ShouldThrowException()
        {
            int[] array = { 1, 2, 3 };
            Action act = () => IsAnEnumerable<int>.WhereTheItemAtPosition(3, IsGreaterThan.Value(2)).Evaluate(array);
            act.Should().Throw<ScreenplayException>()
                 .WithMessage("The informed position is out of the range of the enumerable items!");
        }

        #endregion
    }
}