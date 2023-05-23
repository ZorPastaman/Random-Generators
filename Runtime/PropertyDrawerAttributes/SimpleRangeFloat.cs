// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	/// <summary>
	/// Property Drawer that clamps a value between <see cref="min"/> and <see cref="max"/>.
	/// </summary>
	public sealed class SimpleRangeFloat : PropertyAttribute
	{
		public readonly float min;
		public readonly float max;

		public SimpleRangeFloat(float min, float max)
		{
			this.min = min;
			this.max = max;
		}
	}
}
