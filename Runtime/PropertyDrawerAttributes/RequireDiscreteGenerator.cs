// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using UnityEngine;
using Zor.RandomGenerators.DiscreteDistributions;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	/// <summary>
	/// Property drawer attribute for <see cref="DiscreteGeneratorProviderReference"/> with value type restriction.
	/// </summary>
	public sealed class RequireDiscreteGenerator : PropertyAttribute
	{
		public readonly Type valueType;

		public RequireDiscreteGenerator(Type valueType)
		{
			this.valueType = valueType;
		}
	}
}
