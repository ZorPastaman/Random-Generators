// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BoolXoroshiro128PlusGenerator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.Xoroshiro128PlusDiscreteDistributionFolder +
			"Bool Xoroshiro128Plus Generator Provider",
		fileName = "BoolXoroshiro128PlusGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoolXoroshiro128PlusGeneratorProvider : DiscreteGeneratorProvider<bool>
	{
		[SerializeField] private ulong m_InitialStateA = 1UL;
		[SerializeField] private ulong m_InitialStateB = 1UL;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private BoolXoroshiro128PlusGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoolXoroshiro128PlusGenerator"/>
		/// and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => xoroshiro128PlusGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="BoolXoroshiro128PlusGenerator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => sharedXoroshiro128PlusGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="BoolXoroshiro128PlusGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BoolXoroshiro128PlusGenerator xoroshiro128PlusGenerator
		{
			[Pure]
			get => m_DefaultConstructor
				? new BoolXoroshiro128PlusGenerator()
				: new BoolXoroshiro128PlusGenerator(m_InitialStateA, m_InitialStateB);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolXoroshiro128PlusGenerator"/>.
		/// </summary>
		[NotNull]
		public BoolXoroshiro128PlusGenerator sharedXoroshiro128PlusGenerator =>
			m_sharedGenerator ??= xoroshiro128PlusGenerator;

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

		/// <summary>
		/// If it's true, the default constructor is used. It doesn't use <see cref="initialState"/>.
		/// </summary>
		public bool defaultConstructor
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DefaultConstructor;
			set
			{
				if (m_DefaultConstructor == value)
				{
					return;
				}

				m_DefaultConstructor = value;
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
