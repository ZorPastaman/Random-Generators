// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	/// <summary>
	/// Property Drawer that clamps a value between <see cref="min"/> and <see cref="max"/>.
	/// </summary>
	public sealed class SimpleRangeLong : PropertyAttribute
	{
		public readonly long min;
		public readonly long max;

		public SimpleRangeLong(long min, long max)
		{
			this.min = min;
			this.max = max;
		}
	}
}
