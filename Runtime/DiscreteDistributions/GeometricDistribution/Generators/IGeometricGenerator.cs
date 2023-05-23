﻿// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="GeometricDistribution"/>.
	/// </summary>
	public interface IGeometricGenerator : IDiscreteGenerator<int>
	{
		/// <summary>
		/// True threshold in range (0, 1).
		/// </summary>
		float probability { get; }
	}
}
