// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Round Modificator for <see cref="Func{Single}"/>.
	/// </summary>
	public sealed class RoundModificatorFunc : IContinuousGenerator
	{
		[NotNull] private Func<float> m_dependedFunc;

		/// <summary>
		/// Creates a <see cref="RoundModificatorFunc"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedFunc"></param>
		public RoundModificatorFunc([NotNull] Func<float> dependedFunc)
		{
			m_dependedFunc = dependedFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public RoundModificatorFunc([NotNull] RoundModificatorFunc other)
		{
			m_dependedFunc = other.m_dependedFunc;
		}

		[NotNull]
		public Func<float> dependedFunc
		{
			[Pure]
			get => m_dependedFunc;
			set => m_dependedFunc = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return Mathf.Round(m_dependedFunc());
		}
	}
}
