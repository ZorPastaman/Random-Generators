// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using UnityEngine;
using Zor.RandomGenerators.DiscreteDistributions.DistributionFilters;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	/// <summary>
	/// Property drawer attribute for <see cref="DiscreteFilterProviderReference"/> with value type restriction.
	/// </summary>
	public sealed class RequireDiscreteFilter : PropertyAttribute
	{
		public readonly Type valueType;

		public RequireDiscreteFilter(Type valueType)
		{
			this.valueType = valueType;
		}
	}
}
