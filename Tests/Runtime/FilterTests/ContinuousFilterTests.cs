// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using NUnit.Framework;
using Zor.RandomGenerators.ContinuousDistributions.DistributionFilters;

namespace Zor.RandomGenerators.Tests
{
	public static class ContinuousFilterTests
	{
		[Test]
		public static void AscendantSequenceFilterTest()
		{
			float[] sequence = {-5, -3f, 0f, 1f, 3f};
			Assert.IsTrue(AscendantSequenceFiltering.NeedRegenerate(sequence, 5f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 0f, 4f, 6f};
			Assert.IsFalse(AscendantSequenceFiltering.NeedRegenerate(sequence, 8f, (byte)sequence.Length, 5));
			sequence = new[] {-5, -3f, 0f, 1f, 3f, 4f, 8f};
			Assert.IsTrue(AscendantSequenceFiltering.NeedRegenerate(sequence, 10f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 0f, 4f, 6f, 3f, 8f};
			Assert.IsFalse(AscendantSequenceFiltering.NeedRegenerate(sequence, 10f, (byte)sequence.Length, 5));
			sequence = new[] {10f, 5f, 0f, -2f, -4f};
			Assert.IsFalse(AscendantSequenceFiltering.NeedRegenerate(sequence, 10f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 4f, 6f, 8f};
			Assert.IsFalse(AscendantSequenceFiltering.NeedRegenerate(sequence, 6f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 2f, 4f, 6f};
			Assert.IsFalse(AscendantSequenceFiltering.NeedRegenerate(sequence, 8f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 4f, 6f, 8f};
			Assert.IsFalse(AscendantSequenceFiltering.NeedRegenerate(sequence, 8f, (byte)sequence.Length, 5));
			sequence = new [] {1f};
			Assert.IsTrue(AscendantSequenceFiltering.NeedRegenerate(sequence, 2f, (byte)sequence.Length, 1));
			sequence = new [] {1f};
			Assert.IsFalse(AscendantSequenceFiltering.NeedRegenerate(sequence, 0f, (byte)sequence.Length, 1));
		}

		[Test]
		public static void CloseFilterTest()
		{
			float[] sequence = {0f, 1f, 2f, 3f, 4f};
			Assert.IsTrue(CloseFiltering.NeedRegenerate(sequence, 3f, 0f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(CloseFiltering.NeedRegenerate(sequence, -3f, 0f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, 6f, 0f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, -6f, 0f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(CloseFiltering.NeedRegenerate(sequence, 3f, 2f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(CloseFiltering.NeedRegenerate(sequence, -2f, 2f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, 8f, 2f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, -6f, 2f, 5f, (byte)sequence.Length, 5));
			sequence = new[] {6f, 7f, 8f, 9f, 10f};
			Assert.IsTrue(CloseFiltering.NeedRegenerate(sequence, 7f, 10f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(CloseFiltering.NeedRegenerate(sequence, 12f, 10f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, 16f, 10f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, 3f, 10f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(CloseFiltering.NeedRegenerate(sequence, 7f, 8f, 5f, (byte)sequence.Length, 5));
			Assert.IsTrue(CloseFiltering.NeedRegenerate(sequence, 12f, 8f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, 16f, 8f, 5f, (byte)sequence.Length, 5));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, 3f, 8f, 5f, (byte)sequence.Length, 5));
			sequence = new float[0];
			Assert.IsTrue(CloseFiltering.NeedRegenerate(sequence, 2f, 0f, 5f, (byte)sequence.Length, 0));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, -6f, 0f, 5f, (byte)sequence.Length, 0));
			sequence = new[] {5f, 6f, 7f};
			Assert.IsTrue(CloseFiltering.NeedRegenerate(sequence, 5f, 6f, 3f, (byte)sequence.Length, 3));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, 5f, 6f, 1f, (byte)sequence.Length, 3));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, 5.5f, 6f, 0.9f, (byte)sequence.Length, 3));
			Assert.IsFalse(CloseFiltering.NeedRegenerate(sequence, 0f, 6f, 3f, (byte)sequence.Length, 3));
		}

		[Test]
		public static void DescendantSequenceFilterTest()
		{
			float[] sequence = {3f, 1f, 0f, -1f, -3f};
			Assert.IsTrue(DescendantSequenceFiltering.NeedRegenerate(sequence, -5f, (byte)sequence.Length, 5));
			sequence = new[] {2f, 0f, 2f, -4f, -6f};
			Assert.IsFalse(DescendantSequenceFiltering.NeedRegenerate(sequence, -8f, (byte)sequence.Length, 5));
			sequence = new[] {10f, 8f, 6f, 4f, 2f, 0f, -2f};
			Assert.IsTrue(DescendantSequenceFiltering.NeedRegenerate(sequence, -4f, (byte)sequence.Length, 5));
			sequence = new[] {10f, 8f, 6f, 4f, 2f, 4f, -2f};
			Assert.IsFalse(DescendantSequenceFiltering.NeedRegenerate(sequence, -4f, (byte)sequence.Length, 5));
			sequence = new[] {-4f, -2f, 0f, 5f, 10f};
			Assert.IsFalse(DescendantSequenceFiltering.NeedRegenerate(sequence, -6f, (byte)sequence.Length, 5));
			sequence = new[] {3f, 1f, 0f, -1f, -3f};
			Assert.IsFalse(DescendantSequenceFiltering.NeedRegenerate(sequence, -1f, (byte)sequence.Length, 5));
			sequence = new[] {3f, 1f, 1f, -1f, -3f};
			Assert.IsFalse(DescendantSequenceFiltering.NeedRegenerate(sequence, -4f, (byte)sequence.Length, 5));
			sequence = new[] {3f, 1f, 0f, -1f, -3f};
			Assert.IsFalse(DescendantSequenceFiltering.NeedRegenerate(sequence, -3f, (byte)sequence.Length, 5));
			sequence = new[] {1f};
			Assert.IsTrue(DescendantSequenceFiltering.NeedRegenerate(sequence, 0f, (byte)sequence.Length, 1));
			sequence = new[] {1f};
			Assert.IsFalse(DescendantSequenceFiltering.NeedRegenerate(sequence, 2f, (byte)sequence.Length, 1));
		}

		[Test]
		public static void GreaterFilterTest()
		{
			float[] sequence = {1f, 2f, 3f};
			Assert.IsTrue(GreaterFiltering.NeedRegenerate(sequence, 2f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {-1f, -2f, -3f};
			Assert.IsFalse(GreaterFiltering.NeedRegenerate(sequence, -2f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {-1f, 2f, -3f};
			Assert.IsFalse(GreaterFiltering.NeedRegenerate(sequence, 4f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, 2f, 3f};
			Assert.IsFalse(GreaterFiltering.NeedRegenerate(sequence, -1f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, 5f, 3f, 6f, 1f, 7f};
			Assert.IsTrue(GreaterFiltering.NeedRegenerate(sequence, 2f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, -2f, -3f, -7f, -8f};
			Assert.IsFalse(GreaterFiltering.NeedRegenerate(sequence, -8f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, 2f, 0f};
			Assert.IsFalse(GreaterFiltering.NeedRegenerate(sequence, 1f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, 2f, 3f};
			Assert.IsFalse(GreaterFiltering.NeedRegenerate(sequence, 0f, 0f, (byte)sequence.Length, 3));
			sequence = new float[0];
			Assert.IsTrue(GreaterFiltering.NeedRegenerate(sequence, 1f, 0f, (byte)sequence.Length, 0));
			sequence = new float[0];
			Assert.IsFalse(GreaterFiltering.NeedRegenerate(sequence, -1f, 0f, (byte)sequence.Length, 0));
		}

		[Test]
		public static void InRangeFilterTest()
		{
			float[] sequence = {-0.5f, 0f, 0.5f};
			Assert.IsTrue(InRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			Assert.IsFalse(InRangeFiltering.NeedRegenerate(sequence, 2f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {-0.5f, 0f, 2f};
			Assert.IsFalse(InRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0.5f, 0f, 0.25f};
			Assert.IsTrue(InRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, -0.25f, -2f};
			Assert.IsFalse(InRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, 0f, -0.5f, 0.5f, 0f};
			Assert.IsTrue(InRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, -2f, -0.5f, 0.5f, 0f};
			Assert.IsTrue(InRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, 0f, -0.5f, 0.5f, 2f};
			Assert.IsFalse(InRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, -2f, -0.5f, 0.5f, 0f};
			Assert.IsFalse(InRangeFiltering.NeedRegenerate(sequence, 2f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new float[0];
			Assert.IsTrue(InRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 0));
			Assert.IsFalse(InRangeFiltering.NeedRegenerate(sequence, 2f, -1f, 1f, (byte)sequence.Length, 0));
			Assert.IsFalse(InRangeFiltering.NeedRegenerate(sequence, -2f, -1f, 1f, (byte)sequence.Length, 0));
		}

		[Test]
		public static void LessFilterTest()
		{
			float[] sequence = {-1f, -2f, -3f};
			Assert.IsTrue(LessFiltering.NeedRegenerate(sequence, -2f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, 2f, 3f};
			Assert.IsFalse(LessFiltering.NeedRegenerate(sequence, 2f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {1f, -2f, 3f};
			Assert.IsFalse(LessFiltering.NeedRegenerate(sequence, -4f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {-1f, -2f, -3f};
			Assert.IsFalse(LessFiltering.NeedRegenerate(sequence, 1f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {-1f, -5f, -3f, -6f, -1f, -7f};
			Assert.IsTrue(LessFiltering.NeedRegenerate(sequence, -2f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {-1f, 2f, 3f, 7f, 8f};
			Assert.IsFalse(LessFiltering.NeedRegenerate(sequence, 8f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {-1f, -2f, 0f};
			Assert.IsFalse(LessFiltering.NeedRegenerate(sequence, -1f, 0f, (byte)sequence.Length, 3));
			sequence = new[] {-1f, -2f, -3f};
			Assert.IsFalse(LessFiltering.NeedRegenerate(sequence, 0f, 0f, (byte)sequence.Length, 3));
			sequence = new float[0];
			Assert.IsTrue(LessFiltering.NeedRegenerate(sequence, -1f, 0f, (byte)sequence.Length, 0));
			sequence = new float[0];
			Assert.IsFalse(LessFiltering.NeedRegenerate(sequence, 1f, 0f, (byte)sequence.Length, 0));
		}

		[Test]
		public static void LittleDifferenceTest()
		{
			float[] sequence = {0f, 0.01f, 0.02f};
			Assert.IsTrue(LittleDifferenceFiltering.NeedRegenerate(sequence, 0.03f, 0.02f,
				(byte)sequence.Length, 3));
			sequence = new[] {0f, 0.01f, 0f};
			Assert.IsTrue(LittleDifferenceFiltering.NeedRegenerate(sequence, 0.01f, 0.02f,
				(byte)sequence.Length, 3));
			sequence = new[] {0f, -0.01f, -0.02f};
			Assert.IsTrue(LittleDifferenceFiltering.NeedRegenerate(sequence, -0.03f, 0.02f,
				(byte)sequence.Length, 3));
			sequence = new[] {0f, 0.01f, 5f};
			Assert.IsFalse(LittleDifferenceFiltering.NeedRegenerate(sequence, 5.01f, 0.02f,
				(byte)sequence.Length, 3));
			sequence = new[] {0f, 0.01f, 0.02f};
			Assert.IsFalse(LittleDifferenceFiltering.NeedRegenerate(sequence, 5f, 0.02f,
				(byte)sequence.Length, 3));
			sequence = new[] {0f, -0.1f, 3f, 3.01f, 3.02f};
			Assert.IsTrue(LittleDifferenceFiltering.NeedRegenerate(sequence, 3.01f, 0.02f,
				(byte)sequence.Length, 3));
			sequence = new[] {0f, -0.1f, 3f, 3.01f, 3.02f};
			Assert.IsFalse(LittleDifferenceFiltering.NeedRegenerate(sequence, 4f, 0.02f,
				(byte)sequence.Length, 3));
			sequence = new[] {0f, -0.1f, 3f, 2f, 3.01f};
			Assert.IsFalse(LittleDifferenceFiltering.NeedRegenerate(sequence, 3f, 0.02f,
				(byte)sequence.Length, 3));
			sequence = new[] {1f};
			Assert.IsTrue(LittleDifferenceFiltering.NeedRegenerate(sequence, 1.01f, 0.02f,
				(byte)sequence.Length, 1));
			sequence = new[] {1f};
			Assert.IsFalse(LittleDifferenceFiltering.NeedRegenerate(sequence, 2f, 0.02f,
				(byte)sequence.Length, 1));
		}
		
		[Test]
		public static void NotInRangeFilterTest()
		{
			float[] sequence = {-2f, 3f, 4f};
			Assert.IsTrue(NotInRangeFiltering.NeedRegenerate(sequence, 3f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {-2f, 3f, 4f};
			Assert.IsFalse(NotInRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {-2f, 0f, 4f};
			Assert.IsFalse(NotInRangeFiltering.NeedRegenerate(sequence, 3f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, 0.5f, -2f, 3f, 4f};
			Assert.IsTrue(NotInRangeFiltering.NeedRegenerate(sequence, 3f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, 0.5f, -2f, 3f, 4f};
			Assert.IsFalse(NotInRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {0f, 0.5f, -2f, 0f, 4f};
			Assert.IsFalse(NotInRangeFiltering.NeedRegenerate(sequence, 4f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new float[0];
			Assert.True(NotInRangeFiltering.NeedRegenerate(sequence, 2f, -1f, 1f, (byte)sequence.Length, 0));
			Assert.IsFalse(NotInRangeFiltering.NeedRegenerate(sequence, 0f, -1f, 1f, (byte)sequence.Length, 0));
			sequence = new[] {-2f, 3f, 4f};
			Assert.IsTrue(NotInRangeFiltering.NeedRegenerate(sequence, -3f, -1f, 1f, (byte)sequence.Length, 3));
			sequence = new[] {2f, -3f, -4f};
			Assert.IsTrue(NotInRangeFiltering.NeedRegenerate(sequence, -3f, -1f, 1f, (byte)sequence.Length, 3));
		}
	}
}
