// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate(byte)"/>.
	/// </summary>
	public sealed class BatesGenerator : IBatesGenerator
	{
		private byte m_iids;

		/// <summary>
		/// Creates a <see cref="BatesGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="iids">
		/// How many independent and identically distributed random values are generated.
		/// </param>
		/// <remarks>
		/// <paramref name="iids"/> must be greater than 0.
		/// </remarks>
		public BatesGenerator(byte iids)
		{
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesGenerator([NotNull] BatesGenerator other)
		{
			m_iids = other.m_iids;
		}

		/// <inheritdoc/>
		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public byte iids
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iids;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iids = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return BatesDistribution.Generate(m_iids);
		}
	}
}
