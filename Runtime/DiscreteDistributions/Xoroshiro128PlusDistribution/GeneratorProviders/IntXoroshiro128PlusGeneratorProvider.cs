// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="IntXoroshiro128PlusGenerator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.Xoroshiro128PlusDiscreteDistributionFolder +
			"Int Xoroshiro128Plus Generator Provider",
		fileName = "IntXoroshiro128PlusGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class IntXoroshiro128PlusGeneratorProvider : DiscreteGeneratorProvider<int>
	{
		[SerializeField] private int m_Min = Xoroshiro128PlusDefaults.DefaultMin;
		[SerializeField] private int m_Max = Xoroshiro128PlusDefaults.DefaultMax;
		[SerializeField] private ulong m_InitialStateA = 1UL;
		[SerializeField] private ulong m_InitialStateB = 1UL;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private IntXoroshiro128PlusGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="IntXoroshiro128PlusGenerator"/>
		/// and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => xoroshiro128PlusGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="IntXoroshiro128PlusGenerator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => sharedXoroshiro128PlusGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="IntXoroshiro128PlusGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public IntXoroshiro128PlusGenerator xoroshiro128PlusGenerator
		{
			[Pure]
			get => m_DefaultConstructor
				? new IntXoroshiro128PlusGenerator(m_Min, m_Max)
				: new IntXoroshiro128PlusGenerator(m_InitialStateA, m_InitialStateB, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="IntXoroshiro128PlusGenerator"/>.
		/// </summary>
		[NotNull]
		public IntXoroshiro128PlusGenerator sharedXoroshiro128PlusGenerator => m_sharedGenerator ??= xoroshiro128PlusGenerator;

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

		public int min
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

		public int max
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
