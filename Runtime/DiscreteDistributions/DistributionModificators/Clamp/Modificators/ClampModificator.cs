// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionModificators
{
	/// <summary>
	/// Clamp Modificator for <see cref="IDiscreteGenerator{Int32}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class ClampModificator<T> : IDiscreteGenerator<int> where T : IDiscreteGenerator<int>
	{
		[NotNull] private T m_dependedGenerator;
		private int m_min;
		private int m_max;

		/// <summary>
		/// Creates a <see cref="ClampModificator{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public ClampModificator([NotNull] T dependedGenerator, int min, int max)
		{
			m_dependedGenerator = dependedGenerator;
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ClampModificator([NotNull] ClampModificator<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
			m_min = other.m_min;
			m_max = other.m_max;
		}

		[NotNull]
		public T dependedGenerator
		{
			[Pure]
			get => m_dependedGenerator;
			set => m_dependedGenerator = value;
		}

		public int min
		{
			[Pure]
			get => m_min;
			set => m_min = value;
		}

		public int max
		{
			[Pure]
			get => m_max;
			set => m_max = value;
		}

		/// <inheritdoc/>
		[Pure]
		public int Generate()
		{
			return Mathf.Clamp(m_dependedGenerator.Generate(), m_min, m_max);
		}
	}
}
