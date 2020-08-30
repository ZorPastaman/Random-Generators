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
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 8f, (byte)sequence.Length, 5));
			sequence = new[] {10f, 5f, 0f, -2f, -4f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 10f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 4f, 6f, 8f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 6f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 2f, 4f, 6f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 8f, (byte)sequence.Length, 5));
			sequence = new[] {0f, 2f, 4f, 6f, 8f};
			Assert.IsFalse(AscendantSequenceFilter.NeedRegenerate(sequence, 8f, (byte)sequence.Length, 5));
		}
	}
}
