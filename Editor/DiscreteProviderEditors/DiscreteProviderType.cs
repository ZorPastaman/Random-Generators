// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteProviderEditors
{
	/// <summary>
	/// Attribute for <see cref="DiscreteProviderEditor"/>. It specifies supported types of discrete providers.
	/// It supports generic types.
	/// </summary>
	public sealed class DiscreteProviderType : Attribute
	{
		[NotNull] public readonly Type[] types;

		public DiscreteProviderType([NotNull] params Type[] types)
		{
			this.types = types;
		}
	}
}
