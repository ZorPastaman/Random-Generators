// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Extreme Value Random Generator using <see cref="ExtremeValueDistribution.Generate{T}(T,float,float)"/>.
	/// </summary>
	public sealed class ExtremeValueGeneratorDependent<T> : IExtremeValueGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private float m_location;
		private float m_scale;

		/// <summary>
		/// Creates an <see cref="ExtremeValueGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="location"></param>
		/// <param name="scale">Must be more than 0.</param>
		public ExtremeValueGeneratorDependent([NotNull] T iidGenerator, float location, float scale)
		{
			m_iidGenerator = iidGenerator;
			m_location = location;
			m_scale = scale;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExtremeValueGeneratorDependent([NotNull] ExtremeValueGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_location = other.m_location;
			m_scale = other.m_scale;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </summary>
		[NotNull]
		public T iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidGenerator = value;
		}

		public float location
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_location;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_location = value;
		}

		/// <remarks>Must be more than 0.</remarks>
		public float scale
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_scale;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_scale = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return ExtremeValueDistribution.Generate(m_iidGenerator, m_location, m_scale);
		}
	}
}
