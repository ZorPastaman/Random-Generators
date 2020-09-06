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
	}
}