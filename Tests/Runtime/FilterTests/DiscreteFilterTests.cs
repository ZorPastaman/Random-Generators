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
		public static void FloatExtremeFilterTest()
		{
			float[] sequence = {0f, 1f, 2f, 3f, 4f};
			Assert.IsTrue(FloatExtremeFilter.NeedRegenerate(sequence, 3f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {0f, 1f, 2f, 3f, 4f};
			Assert.IsFalse(FloatExtremeFilter.NeedRegenerate(sequence, 8f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {0f, 1f, 2f, 3f, 4f, 2f, 3f};
			Assert.IsTrue(FloatExtremeFilter.NeedRegenerate(sequence, 3f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {0f, 1f, 2f, 3f, 4f, 2f, 3f};
			Assert.IsFalse(FloatExtremeFilter.NeedRegenerate(sequence, 8f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {1f, 3f, 8f, 4f, 9f};
			Assert.IsFalse(FloatExtremeFilter.NeedRegenerate(sequence, 8f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new float[0];
			Assert.IsTrue(FloatExtremeFilter.NeedRegenerate(sequence, 2f, 0f, 10f, 5f,
				(byte)sequence.Length, 0));
			sequence = new float[0];
			Assert.IsFalse(FloatExtremeFilter.NeedRegenerate(sequence, 5f, 0f, 10f, 3f,
				(byte)sequence.Length, 0));
			sequence = new[] {6f, 7f, 8f, 7f, 9f};
			Assert.IsTrue(FloatExtremeFilter.NeedRegenerate(sequence, 8f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {6f, 7f, 8f, 7f, 9f};
			Assert.IsFalse(FloatExtremeFilter.NeedRegenerate(sequence, 3f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {6f, 3f, 8f, 7f, 9f};
			Assert.IsFalse(FloatExtremeFilter.NeedRegenerate(sequence, 8f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
		}
		
		[Test]
		public static void IntExtremeFilterTest()
		{
			int[] sequence = {0, 1, 2, 3, 4};
			Assert.IsTrue(IntExtremeFilter.NeedRegenerate(sequence, 3, 0, 10, 5,
				(byte)sequence.Length, 5));
			sequence = new[] {0, 1, 2, 3, 4};
			Assert.IsFalse(IntExtremeFilter.NeedRegenerate(sequence, 8, 0, 10, 5,
				(byte)sequence.Length, 5));
			sequence = new[] {0, 1, 2, 3, 4, 2, 3};
			Assert.IsTrue(IntExtremeFilter.NeedRegenerate(sequence, 3, 0, 10, 5,
				(byte)sequence.Length, 5));
			sequence = new[] {0, 1, 2, 3, 4, 2, 3};
			Assert.IsFalse(IntExtremeFilter.NeedRegenerate(sequence, 8, 0, 10, 5,
				(byte)sequence.Length, 5));
			sequence = new[] {1, 3, 8, 4, 9};
			Assert.IsFalse(IntExtremeFilter.NeedRegenerate(sequence, 8, 0, 10, 5,
				(byte)sequence.Length, 5));
			sequence = new int[0];
			Assert.IsTrue(IntExtremeFilter.NeedRegenerate(sequence, 2, 0, 10, 5,
				(byte)sequence.Length, 0));
			sequence = new int[0];
			Assert.IsFalse(IntExtremeFilter.NeedRegenerate(sequence, 5, 0, 10, 3,
				(byte)sequence.Length, 0));
			sequence = new[] {6, 7, 8, 7, 9};
			Assert.IsTrue(IntExtremeFilter.NeedRegenerate(sequence, 8, 0, 10, 5,
				(byte)sequence.Length, 5));
			sequence = new[] {6, 7, 8, 7, 9};
			Assert.IsFalse(IntExtremeFilter.NeedRegenerate(sequence, 3, 0, 10, 5,
				(byte)sequence.Length, 5));
			sequence = new[] {6, 3, 8, 7, 9};
			Assert.IsFalse(IntExtremeFilter.NeedRegenerate(sequence, 8, 0, 10, 5,
				(byte)sequence.Length, 5));
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
	}
}
