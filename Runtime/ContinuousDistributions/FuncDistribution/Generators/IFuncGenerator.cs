// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Generator using <see cref="Func{Single}"/>.
	/// </summary>
	public interface IFuncGenerator : IContinuousGenerator
	{
		[NotNull]
		Func<float> func { get; }
	}
}
