// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// A modificator which clamps a continuous generator between <see cref="min"/> and <see cref="max"/>.
	/// </summary>
	public interface IClampModificator : IContinuousGenerator
	{
		float min { get; }
		float max { get; }
	}
}
