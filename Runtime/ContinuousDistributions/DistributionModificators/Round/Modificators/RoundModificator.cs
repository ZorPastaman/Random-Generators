// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Round Modificator for <see cref="IContinuousGenerator"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class RoundModificator<T> : IContinuousGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;

		/// <summary>
		/// Creates a <see cref="RoundModificator{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator"></param>
		public RoundModificator([NotNull] T dependedGenerator)
		{
			m_dependedGenerator = dependedGenerator;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public RoundModificator([NotNull] RoundModificator<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
		}

		[NotNull]
		public T dependedGenerator
		{
			[Pure]
			get => m_dependedGenerator;
			set => m_dependedGenerator = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return Mathf.Round(m_dependedGenerator.Generate());
		}
	}
}
