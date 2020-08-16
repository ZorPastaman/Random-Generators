// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using UnityEngine;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	public sealed class RequireDiscreteFilter : PropertyAttribute
	{
		public readonly Type valueType;

		public RequireDiscreteFilter(Type valueType)
		{
			this.valueType = valueType;
		}
	}
}
