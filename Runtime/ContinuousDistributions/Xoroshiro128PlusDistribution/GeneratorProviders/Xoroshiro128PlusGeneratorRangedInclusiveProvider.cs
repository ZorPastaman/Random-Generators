// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="Xoroshiro128PlusGeneratorRangedInclusive"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.Xoroshiro128PlusContinuousDistributionFolder +
			"Xoroshiro128Plus Generator Ranged Inclusive Provider",
		fileName = "Xoroshiro128PlusGeneratorRangedInclusiveProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class Xoroshiro128PlusGeneratorRangedInclusiveProvider : ContinuousGeneratorProvider
	{
		[SerializeField] private float m_Min;
		[SerializeField] private float m_Max;
		[SerializeField, Tooltip("Must be non-zero")] private ulong m_InitialStateA = 1UL;
		[SerializeField, Tooltip("Must be non-zero")] private ulong m_InitialStateB = 1UL;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private Xoroshiro128PlusGeneratorRangedInclusive m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="Xoroshiro128PlusGeneratorRangedInclusive"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => xoroshiro128PlusGeneratorRangedInclusive;
		}

		/// <summary>
		/// Returns a shared <see cref="Xoroshiro128PlusGeneratorRangedInclusive"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => sharedXoroshiro128PlusGeneratorRangedInclusive;
		}

		/// <summary>
		/// Creates a new <see cref="Xoroshiro128PlusGeneratorRangedInclusive"/> and returns it.
		/// </summary>
		[NotNull]
		public Xoroshiro128PlusGeneratorRangedInclusive xoroshiro128PlusGeneratorRangedInclusive
		{
			[Pure]
			get => m_DefaultConstructor
				? new Xoroshiro128PlusGeneratorRangedInclusive(m_Min, m_Max)
				: new Xoroshiro128PlusGeneratorRangedInclusive(m_InitialStateA, m_InitialStateB, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="Xoroshiro128PlusGeneratorRangedInclusive"/>.
		/// </summary>
		[NotNull]
		public Xoroshiro128PlusGeneratorRangedInclusive sharedXoroshiro128PlusGeneratorRangedInclusive =>
			m_sharedGenerator ??= xoroshiro128PlusGeneratorRangedInclusive;

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			set
			{
				if (m_Min == value)
				{
					return;
				}

				m_Min = value;
				m_sharedGenerator = null;
			}
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			set
			{
				if (m_Max == value)
				{
					return;
				}

				m_Max = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// Initial state of <see cref="Xoroshiro128Plus"/>. Must be non-zero.
		/// </summary>
		public (ulong, ulong) initialState
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => (m_InitialStateA, m_InitialStateB);
			set
			{
				if (m_InitialStateA == value.Item1 & m_InitialStateB == value.Item2)
				{
					return;
				}

				m_InitialStateA = value.Item1;
				m_InitialStateB = value.Item2;
				m_sharedGenerator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedGenerator = null;
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
