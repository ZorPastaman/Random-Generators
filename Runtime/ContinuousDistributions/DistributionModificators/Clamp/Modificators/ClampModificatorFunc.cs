// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Clamp modificator for <see cref="Func{Single}"/>.
	/// </summary>
	public sealed class ClampModificatorFunc : IContinuousGenerator
	{
		[NotNull] private Func<float> m_dependedFunc;
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates a <see cref="ClampModificatorFunc"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedFunc"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public ClampModificatorFunc([NotNull] Func<float> dependedFunc, float min, float max)
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
		public Func<float> dependedFunc
		{
			[Pure]
			get => m_dependedFunc;
			set => m_dependedFunc = value;
		}

		public float min
		{
			[Pure]
			get => m_min;
			set => m_min = value;
		}

		public float max
		{
			[Pure]
			get => m_max;
			set => m_max = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return Mathf.Clamp(m_dependedFunc(), m_min, m_max);
		}
	}
}
