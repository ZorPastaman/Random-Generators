// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using NUnit.Framework;
using Zor.RandomGenerators.ContinuousDistributions.DistributionFilters;

namespace Zor.RandomGenerators.Tests
{
	public static class FilterTests
	{
		[Test]
		public static void AscendantSequenceFilterTest()
		{
			float[] sequence = {-5, -3f, 0f, 1f, 3f};
			Assert.IsTrue(AscendantSequenceFilter.NeedRegenerate(sequence, 5f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 0f, 4f, 6f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 8f, (byte)sequence.Length, 5));
			sequence = new[] {-5, -3f, 0f, 1f, 3f, 4f, 8f};
			Assert.IsTrue(AscendantSequenceFilter.NeedRegenerate(sequence, 10f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 0f, 4f, 6f, 3f, 8f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 10f, (byte)sequence.Length, 5));
			sequence = new[] {10f, 5f, 0f, -2f, -4f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 10f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 4f, 6f, 8f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 6f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 2f, 4f, 6f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 8f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 4f, 6f, 8f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 8f, (byte)sequence.Length, 5));
			sequence = new [] {1f};
			Assert.IsTrue(AscendantSequenceFilter.NeedRegenerate(sequence, 2f, (byte)sequence.Length, 1));
			sequence = new [] {1f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 0f, (byte)sequence.Length, 1));
		}

		[Test]
		public static void DescendantSequenceFilterTest()
		{
			float[] sequence = {3f, 1f, 0f, -1f, -3f};
			Assert.IsTrue(DescendantSequenceFilter.NeedRegenerate(sequence, -5f, (byte)sequence.Length, 5));
			sequence = new[] {2f, 0f, 2f, -4f, -6f};
			Assert.IsFalse(DescendantSequenceFilter.NeedRegenerate(sequence, -8f, (byte)sequence.Length, 5));
			sequence = new[] {10f, 8f, 6f, 4f, 2f, 0f, -2f};
			Assert.IsTrue(DescendantSequenceFilter.NeedRegenerate(sequence, -4f, (byte)sequence.Length, 5));
			sequence = new[] {10f, 8f, 6f, 4f, 2f, 4f, -2f};
			Assert.IsFalse(DescendantSequenceFilter.NeedRegenerate(sequence, -4f, (byte)sequence.Length, 5));
			sequence = new[] {-4f, -2f, 0f, 5f, 10f};
			Assert.IsFalse(DescendantSequenceFilter.NeedRegenerate(sequence, -6f, (byte)sequence.Length, 5));
			sequence = new[] {3f, 1f, 0f, -1f, -3f};
			Assert.IsFalse(DescendantSequenceFilter.NeedRegenerate(sequence, -1f, (byte)sequence.Length, 5));
			sequence = new[] {3f, 1f, 1f, -1f, -3f};
			Assert.IsFalse(DescendantSequenceFilter.NeedRegenerate(sequence, -4f, (byte)sequence.Length, 5));
			sequence = new[] {3f, 1f, 0f, -1f, -3f};
			Assert.IsFalse(DescendantSequenceFilter.NeedRegenerate(sequence, -3f, (byte)sequence.Length, 5));
			sequence = new[] {1f};
			Assert.IsTrue(DescendantSequenceFilter.NeedRegenerate(sequence, 0f, (byte)sequence.Length, 1));
			sequence = new[] {1f};
			Assert.IsFalse(DescendantSequenceFilter.NeedRegenerate(sequence, 2f, (byte)sequence.Length, 1));
		}

		[Test]
		public static void ExtremeFilterTest()
		{
			float[] sequence = {0f, 1f, 2f, 3f, 4f};
			Assert.IsTrue(ExtremeFilter.NeedRegenerate(sequence, 3f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {0f, 1f, 2f, 3f, 4f};
			Assert.IsFalse(ExtremeFilter.NeedRegenerate(sequence, 8f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {0f, 1f, 2f, 3f, 4f, 2f, 3f};
			Assert.IsTrue(ExtremeFilter.NeedRegenerate(sequence, 3f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {0f, 1f, 2f, 3f, 4f, 2f, 3f};
			Assert.IsFalse(ExtremeFilter.NeedRegenerate(sequence, 8f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {1f, 3f, 8f, 4f, 9f};
			Assert.IsFalse(ExtremeFilter.NeedRegenerate(sequence, 8f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new float[0];
			Assert.IsTrue(ExtremeFilter.NeedRegenerate(sequence, 2f, 0f, 10f, 5f,
				(byte)sequence.Length, 0));
			sequence = new float[0];
			Assert.IsFalse(ExtremeFilter.NeedRegenerate(sequence, 5f, 0f, 10f, 3f,
				(byte)sequence.Length, 0));
			sequence = new[] {6f, 7f, 8f, 7f, 9f};
			Assert.IsTrue(ExtremeFilter.NeedRegenerate(sequence, 8f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {6f, 7f, 8f, 7f, 9f};
			Assert.IsFalse(ExtremeFilter.NeedRegenerate(sequence, 3f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
			sequence = new[] {6f, 3f, 8f, 7f, 9f};
			Assert.IsFalse(ExtremeFilter.NeedRegenerate(sequence, 8f, 0f, 10f, 5f,
				(byte)sequence.Length, 5));
		}

		[Test]
		public static void GreaterFilterTest()
		{
			float[] sequence = {1f, 2f, 3f};
			Assert.IsTrue(GreaterFilter.NeedRegenerate(sequence, 2f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {-1f, -2f, -3f};
			Assert.IsFalse(GreaterFilter.NeedRegenerate(sequence, -2f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {-1f, 2f, -3f};
			Assert.IsFalse(GreaterFilter.NeedRegenerate(sequence, 4f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, 2f, 3f};
			Assert.IsFalse(GreaterFilter.NeedRegenerate(sequence, -1f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, 5f, 3f, 6f, 1f, 7f};
			Assert.IsTrue(GreaterFilter.NeedRegenerate(sequence, 2f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, -2f, -3f, -7f, -8f};
			Assert.IsFalse(GreaterFilter.NeedRegenerate(sequence, -8f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, 2f, 0f};
			Assert.IsFalse(GreaterFilter.NeedRegenerate(sequence, 1f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, 2f, 3f};
			Assert.IsFalse(GreaterFilter.NeedRegenerate(sequence, 0f, 0f, (byte)sequence.Length, 3));
			sequence = new float[0];
			Assert.IsTrue(GreaterFilter.NeedRegenerate(sequence, 1f, 0f, (byte)sequence.Length, 0));
			sequence = new float[0];
			Assert.IsFalse(GreaterFilter.NeedRegenerate(sequence, -1f, 0f, (byte)sequence.Length, 0));
		}

		[Test]
		public static void InRangeFilterTest()
		{
			float[] sequence = {-0.5f, 0f, 0.5f};
			Assert.IsTrue(InRangeFilter.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			Assert.IsFalse(InRangeFilter.NeedRegenerate(sequence, 2f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {-0.5f, 0f, 2f};
			Assert.IsFalse(InRangeFilter.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0.5f, 0f, 0.25f};
			Assert.IsTrue(InRangeFilter.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, -0.25f, -2f};
			Assert.IsFalse(InRangeFilter.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, 0f, -0.5f, 0.5f, 0f};
			Assert.IsTrue(InRangeFilter.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, -2f, -0.5f, 0.5f, 0f};
			Assert.IsTrue(InRangeFilter.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, 0f, -0.5f, 0.5f, 2f};
			Assert.IsFalse(InRangeFilter.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, -2f, -0.5f, 0.5f, 0f};
			Assert.IsFalse(InRangeFilter.NeedRegenerate(sequence, 2f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new float[0];
			Assert.IsTrue(InRangeFilter.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 0));
			Assert.IsFalse(InRangeFilter.NeedRegenerate(sequence, 2f, -1f, 1f, (byte)sequence.Length, 0));
			Assert.IsFalse(InRangeFilter.NeedRegenerate(sequence, -2f, -1f, 1f, (byte)sequence.Length, 0));
		}
	}
}
