// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Extreme Value Random Generator using <see cref="ExtremeValueDistribution.Generate(float,float)"/>.
	/// </summary>
	public sealed class ExtremeValueGenerator : IExtremeValueGenerator
	{
		private float m_location;
		private float m_scale;

		/// <summary>
		/// Creates an <see cref="ExtremeValueGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="location"></param>
		/// <param name="scale"></param>
		public ExtremeValueGenerator(float location, float scale)
		{
			m_location = location;
			m_scale = scale;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExtremeValueGenerator([NotNull] ExtremeValueGenerator other)
		{
			m_location = other.m_location;
			m_scale = other.m_scale;
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
			return ExtremeValueDistribution.Generate(m_location, m_scale);
		}
	}
}
