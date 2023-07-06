// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="Xoroshiro128PlusGenerator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.Xoroshiro128PlusContinuousDistributionFolder +
			"Xoroshiro128Plus Generator Provider",
		fileName = "Xoroshiro128PlusGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class Xoroshiro128PlusGeneratorProvider : ContinuousGeneratorProvider
	{
		[SerializeField, Tooltip("Must be non-zero")] private ulong m_InitialStateA = 1UL;
		[SerializeField, Tooltip("Must be non-zero")] private ulong m_InitialStateB = 1UL;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private Xoroshiro128PlusGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="Xoroshiro128PlusGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => xoroshiro128PlusGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="Xoroshiro128PlusGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => sharedXoroshiro128PlusGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="Xoroshiro128PlusGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public Xoroshiro128PlusGenerator xoroshiro128PlusGenerator
		{
			[Pure]
			get => m_DefaultConstructor
				? new Xoroshiro128PlusGenerator()
				: new Xoroshiro128PlusGenerator(m_InitialStateA, m_InitialStateB);
		}

		/// <summary>
		/// Returns a shared <see cref="Xoroshiro128PlusGenerator"/>.
		/// </summary>
		[NotNull]
		public Xoroshiro128PlusGenerator sharedXoroshiro128PlusGenerator =>
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
