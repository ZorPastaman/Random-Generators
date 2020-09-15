// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using NUnit.Framework;
using Zor.RandomGenerators.DiscreteDistributions.DistributionFilters;

namespace Zor.RandomGenerators.Tests
{
	public static class DiscreteFilterTests
	{
		[Test]
		public static void AscendantSequenceFilterTest()
		{
			int[] sequence = {-5, -3, 0, 1, 3};
			Assert.IsTrue(AscendantSequenceFilter<int>.NeedRegenerate(sequence, 5, (byte)sequence.Length, 5));
			sequence = new[] {0, 2, 0, 4, 6};
			Assert.IsFalse(AscendantSequenceFilter<int>.NeedRegenerate(sequence, 8, (byte)sequence.Length, 5));
			sequence = new[] {-5, -3, 0, 1, 3, 4, 8};
			Assert.IsTrue(AscendantSequenceFilter<int>.NeedRegenerate(sequence, 10, (byte)sequence.Length, 5));
			sequence = new[] {0, 2, 0, 4, 6, 3, 8};
			Assert.IsFalse(AscendantSequenceFilter<int>.NeedRegenerate(sequence, 10, (byte)sequence.Length, 5));
			sequence = new[] {10, 5, 0, -2, -4};
			Assert.IsFalse(AscendantSequenceFilter<int>.NeedRegenerate(sequence, 10, (byte)sequence.Length, 5));
			sequence = new[] {0, 2, 4, 6, 8};
			Assert.IsFalse(AscendantSequenceFilter<int>.NeedRegenerate(sequence, 6, (byte)sequence.Length, 5));
			sequence = new[] {0, 2, 2, 4, 6};
			Assert.IsFalse(AscendantSequenceFilter<int>.NeedRegenerate(sequence, 8, (byte)sequence.Length, 5));
			sequence = new[] {0, 2, 4, 6, 8};
			Assert.IsFalse(AscendantSequenceFilter<int>.NeedRegenerate(sequence, 8, (byte)sequence.Length, 5));
			sequence = new [] {1};
			Assert.IsTrue(AscendantSequenceFilter<int>.NeedRegenerate(sequence, 2, (byte)sequence.Length, 1));
			sequence = new [] {1};
			Assert.IsFalse(AscendantSequenceFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 1));
		}
		
		[Test]
		public static void FloatCloseFilterTest()
		{
			float[] sequence = {0f, 1f, 2f, 3f, 4f};
			Assert.IsTrue(FloatCloseFilter.NeedRegenerate(sequence, 3f, 0f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(FloatCloseFilter.NeedRegenerate(sequence, -3f, 0f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, 6f, 0f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, -6f, 0f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(FloatCloseFilter.NeedRegenerate(sequence, 3f, 2f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(FloatCloseFilter.NeedRegenerate(sequence, -2f, 2f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, 8f, 2f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, -6f, 2f, 5f, (byte)sequence.Length, 5));
			sequence = new[] {6f, 7f, 8f, 9f, 10f};
			Assert.IsTrue(FloatCloseFilter.NeedRegenerate(sequence, 7f, 10f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(FloatCloseFilter.NeedRegenerate(sequence, 12f, 10f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, 16f, 10f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, 3f, 10f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(FloatCloseFilter.NeedRegenerate(sequence, 7f, 8f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(FloatCloseFilter.NeedRegenerate(sequence, 12f, 8f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, 16f, 8f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, 3f, 8f, 5f, (byte)sequence.Length, 5));
			sequence = new float[0];
			Assert.IsTrue(FloatCloseFilter.NeedRegenerate(sequence, 2f, 0f, 5f, (byte)sequence.Length, 0));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, -6f, 0f, 5f, (byte)sequence.Length, 0));
			sequence = new[] {5f, 6f, 7f};
			Assert.IsTrue(FloatCloseFilter.NeedRegenerate(sequence, 5f, 6f, 3f, (byte)sequence.Length, 3));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, 5f, 6f, 1f, (byte)sequence.Length, 3));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, 5.5f, 6f, 0.9f, (byte)sequence.Length, 3));
			Assert.IsFalse(FloatCloseFilter.NeedRegenerate(sequence, 0f, 6f, 3f, (byte)sequence.Length, 3));
		}
		
		[Test]
		public static void IntCloseFilterTest()
		{
			int[] sequence = {0, 1, 2, 3, 4};
			Assert.IsTrue(IntCloseFilter.NeedRegenerate(sequence, 3, 0, 5, (byte)sequence.Length, 5));
			Assert.IsTrue(IntCloseFilter.NeedRegenerate(sequence, -3, 0, 5, (byte)sequence.Length, 5));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, 6, 0, 5, (byte)sequence.Length, 5));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, -6, 0, 5, (byte)sequence.Length, 5));
			Assert.IsTrue(IntCloseFilter.NeedRegenerate(sequence, 3, 2, 5, (byte)sequence.Length, 5));
			Assert.IsTrue(IntCloseFilter.NeedRegenerate(sequence, -2, 2, 5, (byte)sequence.Length, 5));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, 8, 2, 5, (byte)sequence.Length, 5));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, -6, 2, 5, (byte)sequence.Length, 5));
			sequence = new[] {6, 7, 8, 9, 10};
			Assert.IsTrue(IntCloseFilter.NeedRegenerate(sequence, 7, 10, 5, (byte)sequence.Length, 5));
			Assert.IsTrue(IntCloseFilter.NeedRegenerate(sequence, 12, 10, 5, (byte)sequence.Length, 5));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, 16, 10, 5, (byte)sequence.Length, 5));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, 3, 10, 5, (byte)sequence.Length, 5));
			Assert.IsTrue(IntCloseFilter.NeedRegenerate(sequence, 7, 8, 5, (byte)sequence.Length, 5));
			Assert.IsTrue(IntCloseFilter.NeedRegenerate(sequence, 12, 8, 5, (byte)sequence.Length, 5));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, 16, 8, 5, (byte)sequence.Length, 5));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, 3, 8, 5, (byte)sequence.Length, 5));
			sequence = new int[0];
			Assert.IsTrue(IntCloseFilter.NeedRegenerate(sequence, 2, 0, 5, (byte)sequence.Length, 0));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, -6, 0, 5, (byte)sequence.Length, 0));
			sequence = new[] {5, 6, 7};
			Assert.IsTrue(IntCloseFilter.NeedRegenerate(sequence, 5, 6, 3, (byte)sequence.Length, 3));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, 5, 6, 1, (byte)sequence.Length, 3));
			Assert.IsFalse(IntCloseFilter.NeedRegenerate(sequence, 0, 6, 3, (byte)sequence.Length, 3));
		}

		[Test]
		public static void DescendantSequenceFilterTest()
		{
			int[] sequence = {3, 1, 0, -1, -3};
			Assert.IsTrue(DescendantSequenceFilter<int>.NeedRegenerate(sequence, -5, (byte)sequence.Length, 5));
			sequence = new[] {2, 0, 2, -4, -6};
			Assert.IsFalse(DescendantSequenceFilter<int>.NeedRegenerate(sequence, -8, (byte)sequence.Length, 5));
			sequence = new[] {10, 8, 6, 4, 2, 0, -2};
			Assert.IsTrue(DescendantSequenceFilter<int>.NeedRegenerate(sequence, -4, (byte)sequence.Length, 5));
			sequence = new[] {10, 8, 6, 4, 2, 4, -2};
			Assert.IsFalse(DescendantSequenceFilter<int>.NeedRegenerate(sequence, -4, (byte)sequence.Length, 5));
			sequence = new[] {-4, -2, 0, 5, 10};
			Assert.IsFalse(DescendantSequenceFilter<int>.NeedRegenerate(sequence, -6, (byte)sequence.Length, 5));
			sequence = new[] {3, 1, 0, -1, -3};
			Assert.IsFalse(DescendantSequenceFilter<int>.NeedRegenerate(sequence, -1, (byte)sequence.Length, 5));
			sequence = new[] {3, 1, 1, -1, -3};
			Assert.IsFalse(DescendantSequenceFilter<int>.NeedRegenerate(sequence, -4, (byte)sequence.Length, 5));
			sequence = new[] {3, 1, 0, -1, -3};
			Assert.IsFalse(DescendantSequenceFilter<int>.NeedRegenerate(sequence, -3, (byte)sequence.Length, 5));
			sequence = new[] {1};
			Assert.IsTrue(DescendantSequenceFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 1));
			sequence = new[] {1};
			Assert.IsFalse(DescendantSequenceFilter<int>.NeedRegenerate(sequence, 2, (byte)sequence.Length, 1));
		}

		[Test]
		public static void FrequentValueFilterTest()
		{
			int[] sequence = {1, 2};
			Assert.IsTrue(FrequentValueFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 2, 0));
			Assert.IsFalse(FrequentValueFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 2, 1));
			sequence = new[] {-2, 1, 2, 1};
			Assert.IsTrue(FrequentValueFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 2, 0));
			Assert.IsFalse(FrequentValueFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 2, 1));
			Assert.IsTrue(FrequentValueFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 3, 1));
			Assert.IsFalse(FrequentValueFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 3, 2));
			sequence = new[] {1};
			Assert.IsTrue(FrequentValueFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 1, 0));
			sequence = new[] {0};
			Assert.IsFalse(FrequentValueFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 1, 0));
		}

		[Test]
		public static void BoolOppositePatternFilterTest()
		{
			bool[] sequence = {false, false, false, true, true};
			Assert.IsTrue(BoolOppositePatternFilter.NeedRegenerate(sequence, true, (byte)sequence.Length, 3));
			Assert.IsFalse(BoolOppositePatternFilter.NeedRegenerate(sequence, false, (byte)sequence.Length, 3));
			sequence = new[] {false, true, false, true, false};
			Assert.IsTrue(BoolOppositePatternFilter.NeedRegenerate(sequence, true, (byte)sequence.Length, 3));
			Assert.IsFalse(BoolOppositePatternFilter.NeedRegenerate(sequence, false, (byte)sequence.Length, 3));
			sequence = new[] {false, true, true, false, false, false, true, true};
			Assert.IsTrue(BoolOppositePatternFilter.NeedRegenerate(sequence, true, (byte)sequence.Length, 3));
			Assert.IsFalse(BoolOppositePatternFilter.NeedRegenerate(sequence, false, (byte)sequence.Length, 3));
			sequence = new[] {false, true, false, false, false, false, true, true};
			Assert.IsTrue(BoolOppositePatternFilter.NeedRegenerate(sequence, true, (byte)sequence.Length, 3));
			Assert.IsFalse(BoolOppositePatternFilter.NeedRegenerate(sequence, false, (byte)sequence.Length, 3));
			sequence = new[] {true};
			Assert.IsTrue(BoolOppositePatternFilter.NeedRegenerate(sequence, false, (byte)sequence.Length, 1));
			Assert.IsFalse(BoolOppositePatternFilter.NeedRegenerate(sequence, true, (byte)sequence.Length, 1));
		}

		[Test]
		public static void PairFilterTest()
		{
			int[] sequence = {1};
			Assert.IsTrue(PairFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 0));
			Assert.IsFalse(PairFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 0));
			sequence = new[] {1, 0};
			Assert.IsTrue(PairFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 1));
			Assert.IsFalse(PairFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 1));
			Assert.IsTrue(PairFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 0));
			Assert.IsFalse(PairFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 0));
			sequence = new[] {1, 2, 1, 4, -5, 6, 0};
			Assert.IsTrue(PairFilter<int>.NeedRegenerate(sequence, 4, (byte)sequence.Length, 3));
			Assert.IsFalse(PairFilter<int>.NeedRegenerate(sequence, 6, (byte)sequence.Length, 3));
		}

		[Test]
		public static void RepeatingPatternFilterTest()
		{
			int[] sequence = {3, 5, 6, 1, 3};
			Assert.IsTrue(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 5, (byte)sequence.Length, 5, 2));
			Assert.IsFalse(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 3, (byte)sequence.Length, 5, 2));
			sequence = new[] {3, 5, 6, 9, 1, 3, 5};
			Assert.IsTrue(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 6, (byte)sequence.Length, 7, 3));
			Assert.IsFalse(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 5, (byte)sequence.Length, 7, 3));
			sequence = new[] {3, 5, 6, 9, 1, 4, 5};
			Assert.IsFalse(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 6, (byte)sequence.Length, 7, 3));
			Assert.IsTrue(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 6, (byte)sequence.Length, 7, 2));
			sequence = new[] {4, 5, 6, 3, 5, 3, 5};
			Assert.IsTrue(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 3,(byte)sequence.Length, 7, 2));
			Assert.IsFalse(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 3, (byte)sequence.Length, 7, 3));
			sequence = new[] {1, 2, 1};
			Assert.IsTrue(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 2, (byte)sequence.Length, 3, 2));
			Assert.IsFalse(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 3, 2));
			sequence = new[] {3, 5, 4, 5, 1, 4, 5};
			Assert.IsTrue(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 5, 3));
			Assert.IsTrue(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 5, 2));
			Assert.IsFalse(RepeatingPatternFilter<int>.NeedRegenerate(sequence, 2, (byte)sequence.Length, 5, 3));
		}

		[Test]
		public static void SamePatternFilterTest()
		{
			int[] sequence = {1, 1, 1, 1, 1};
			Assert.IsTrue(SamePatternFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 3));
			Assert.IsFalse(SamePatternFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 3));
			sequence = new[] {0, 1, 3, 0, 1};
			Assert.IsTrue(SamePatternFilter<int>.NeedRegenerate(sequence, 3, (byte)sequence.Length, 3));
			Assert.IsFalse(SamePatternFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 3));
			sequence = new[] {5, 6, 4, 2, 1, 0, 2, 1};
			Assert.IsTrue(SamePatternFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 3));
			Assert.IsFalse(SamePatternFilter<int>.NeedRegenerate(sequence, 6, (byte)sequence.Length, 3));
			sequence = new[] {1, 3, 4, 1, 0, 6, 1, 0};
			Assert.IsTrue(SamePatternFilter<int>.NeedRegenerate(sequence, 6, (byte)sequence.Length, 3));
			Assert.IsFalse(SamePatternFilter<int>.NeedRegenerate(sequence, 7, (byte)sequence.Length, 3));
			sequence = new[] {1};
			Assert.IsTrue(SamePatternFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 1));
			Assert.IsFalse(SamePatternFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 1));
			sequence = new[] {3, 4, 5, 7, 4, 3, 4};
			Assert.IsFalse(SamePatternFilter<int>.NeedRegenerate(sequence, 5, (byte)sequence.Length, 3));
		}

		[Test]
		public static void SameSequenceFilterTest()
		{
			int[] sequence = {1};
			Assert.IsTrue(SameSequenceFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 1));
			Assert.IsFalse(SameSequenceFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 1));
			sequence = new[] {2, 0, 0};
			Assert.IsTrue(SameSequenceFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 2));
			Assert.IsFalse(SameSequenceFilter<int>.NeedRegenerate(sequence, 1, (byte)sequence.Length, 2));
			sequence = new[] {0, 2, 0};
			Assert.IsFalse(SameSequenceFilter<int>.NeedRegenerate(sequence, 0, (byte)sequence.Length, 2));
			Assert.IsFalse(SameSequenceFilter<int>.NeedRegenerate(sequence, 2, (byte)sequence.Length, 2));
			sequence = new[] {5, 0, 3, 5, 3, 8, 8};
			Assert.IsTrue(SameSequenceFilter<int>.NeedRegenerate(sequence, 8, (byte)sequence.Length, 2));
			Assert.IsFalse(SameSequenceFilter<int>.NeedRegenerate(sequence, 3, (byte)sequence.Length, 2));
			sequence = new[] {5, 0, 3, 5, 8, 8, 8};
			Assert.IsTrue(SameSequenceFilter<int>.NeedRegenerate(sequence, 8, (byte)sequence.Length, 3));
			Assert.IsFalse(SameSequenceFilter<int>.NeedRegenerate(sequence, 3, (byte)sequence.Length, 3));
			Assert.IsTrue(SameSequenceFilter<int>.NeedRegenerate(sequence, 8, (byte)sequence.Length, 2));
			Assert.IsFalse(SameSequenceFilter<int>.NeedRegenerate(sequence, 3, (byte)sequence.Length, 2));
		}
	}
}
