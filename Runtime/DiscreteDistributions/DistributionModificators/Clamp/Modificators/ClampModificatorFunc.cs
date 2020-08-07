// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionModificators
{
	/// <summary>
	/// Clamp Modificator for <see cref="Func{Int32}"/>.
	/// </summary>
	public sealed class ClampModificatorFunc : IDiscreteGenerator<int>
	{
		[NotNull] private Func<int> m_dependedFunc;
		private int m_min;
		private int m_max;

		/// <summary>
		/// Creates a <see cref="ClampModificatorFunc"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedFunc"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public ClampModificatorFunc([NotNull] Func<int> dependedFunc, int min, int max)
		{
			m_dependedFunc = dependedFunc;
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ClampModificatorFunc([NotNull] ClampModificatorFunc other)
		{
			m_dependedFunc = other.m_dependedFunc;
			m_min = other.m_min;
			m_max = other.m_max;
		}

		[NotNull]
		public Func<int> dependedFunc
		{
			[Pure]
			get => m_dependedFunc;
			set => m_dependedFunc = value;
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
			return Mathf.Clamp(m_dependedFunc(), m_min, m_max);
		}
	}
}
