// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Normal Random Generator using <see cref="NormalDistribution.Generate(float,float)"/>.
	/// </summary>
	public sealed class NormalGenerator : INormalGenerator
	{
		private float m_mean;
		private float m_deviation;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="NormalGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		public NormalGenerator(float mean, float deviation)
		{
			m_mean = mean;
			m_deviation = deviation;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public NormalGenerator([NotNull] NormalGenerator other)
		{
			m_mean = other.m_mean;
			m_deviation = other.m_deviation;
		}

		public float mean
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_mean;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_mean = value;
				m_hasSpared = false;
			}
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_deviation;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_deviation = value;
				m_hasSpared = false;
			}
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			if (m_hasSpared)
			{
				m_hasSpared = false;
				return m_spared;
			}

			float answer;
			(answer, m_spared) = NormalDistribution.Generate(m_mean, m_deviation);
			m_hasSpared = true;

			return answer;
		}
	}
}
