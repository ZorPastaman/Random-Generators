// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate{T}(T,byte)"/>.
	/// </summary>
	public sealed class IrwinHallGeneratorDependentSimple<T> : IIrwinHallGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;
		private byte m_iids;

		/// <summary>
		/// Creates an <see cref="IrwinHallGeneratorDependentSimple{T}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="iids">How many independent and identically distributed random variables are generated.</param>
		public IrwinHallGeneratorDependentSimple([NotNull] T dependedGenerator, byte iids)
		{
			m_dependedGenerator = dependedGenerator;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public IrwinHallGeneratorDependentSimple([NotNull] IrwinHallGeneratorDependentSimple<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
			m_iids = other.m_iids;
		}

		/// <summary>
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public T dependedRandomGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_dependedGenerator = value;
		}

		public float startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => IrwinHallDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
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
			return IrwinHallDistribution.Generate(m_dependedGenerator, m_iids);
		}
	}
}
