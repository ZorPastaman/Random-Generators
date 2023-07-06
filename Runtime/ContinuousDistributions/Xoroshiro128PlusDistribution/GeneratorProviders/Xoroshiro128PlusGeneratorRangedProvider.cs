// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="Xoroshiro128PlusGeneratorRanged"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.Xoroshiro128PlusContinuousDistributionFolder +
			"Xoroshiro128Plus Generator Ranged Provider",
		fileName = "Xoroshiro128PlusGeneratorRangedProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class Xoroshiro128PlusGeneratorRangedProvider : ContinuousGeneratorProvider
	{
		[SerializeField] private float m_Min;
		[SerializeField] private float m_Max;
		[SerializeField, Tooltip("Must be non-zero")] private ulong m_InitialStateA = 1UL;
		[SerializeField, Tooltip("Must be non-zero")] private ulong m_InitialStateB = 1UL;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private Xoroshiro128PlusGeneratorRanged m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="Xoroshiro128PlusGeneratorRanged"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => xoroshiro128PlusGeneratorRanged;
		}

		/// <summary>
		/// Returns a shared <see cref="Xoroshiro128PlusGeneratorRanged"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => sharedXoroshiro128PlusGeneratorRanged;
		}

		/// <summary>
		/// Creates a new <see cref="Xoroshiro128PlusGeneratorRanged"/> and returns it.
		/// </summary>
		[NotNull]
		public Xoroshiro128PlusGeneratorRanged xoroshiro128PlusGeneratorRanged
		{
			[Pure]
			get => m_DefaultConstructor
				? new Xoroshiro128PlusGeneratorRanged(m_Min, m_Max)
				: new Xoroshiro128PlusGeneratorRanged(m_InitialStateA, m_InitialStateB, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="Xoroshiro128PlusGeneratorRanged"/>.
		/// </summary>
		[NotNull]
		public Xoroshiro128PlusGeneratorRanged sharedXoroshiro128PlusGeneratorRanged =>
			m_sharedGenerator ??= xoroshiro128PlusGeneratorRanged;

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
