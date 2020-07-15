// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using UnityEngine;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	/// <summary>
	/// Property drawer attribute for
	/// <see cref="Zor.RandomGenerators.DiscreteDistributions.DiscreteRandomGeneratorProviderReference"/>
	/// with value type restriction.
	/// </summary>
	public sealed class RequireDiscreteRandomGenerator : PropertyAttribute
	{
		public readonly Type valueType;

		public RequireDiscreteRandomGenerator(Type valueType)
		{
			this.valueType = valueType;
		}
	}
}
