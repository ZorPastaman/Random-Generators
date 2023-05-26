// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Extreme Value Random Generator using <see cref="ExtremeValueDistribution.Generate(Func{float},float,float)"/>.
	/// </summary>
	public sealed class ExtremeValueGeneratorFuncDependent : IExtremeValueGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_location;
		private float m_scale;

		/// <summary>
		/// Creates an <see cref="ExtremeValueGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="location"></param>
		/// <param name="scale">Must be more than 0.</param>
		public ExtremeValueGeneratorFuncDependent([NotNull] Func<float> iidFunc, float location, float scale)
		{
			m_iidFunc = iidFunc;
			m_location = location;
			m_scale = scale;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExtremeValueGeneratorFuncDependent([NotNull] ExtremeValueGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_location = other.m_location;
			m_scale = other.m_scale;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </summary>
		[NotNull]
		public Func<float> iidFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidFunc = value;
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
			return ExtremeValueDistribution.Generate(m_iidFunc, m_location, m_scale);
		}
	}
}
