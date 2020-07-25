// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate(Func{float,float},float,float)"/>.
	/// </summary>
	public sealed class AcceptanceRejectionFuncRandomGenerator : IAcceptanceRejectionRandomGenerator
	{
		[NotNull] private Func<float, float> m_probabilityFunc;
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionFuncRandomGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public AcceptanceRejectionFuncRandomGenerator([NotNull] Func<float, float> probabilityFunc,
			float min, float max)
		{
			m_probabilityFunc = probabilityFunc;
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionFuncRandomGenerator([NotNull] AcceptanceRejectionFuncRandomGenerator other)
		{
			m_probabilityFunc = other.m_probabilityFunc;
			m_min = other.m_min;
			m_max = other.m_max;
		}

		/// <summary>
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </summary>
		[NotNull]
		public Func<float, float> probabilityFunc
		{
			[Pure]
			get => m_probabilityFunc;
			set => m_probabilityFunc = value;
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
			return AcceptanceRejectionDistribution.Generate(m_probabilityFunc, m_min, m_max);
		}
	}
}
