// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BoolLCG64Generator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LCG64DiscreteDistributionFolder + "Bool LCG64 Generator Provider",
		fileName = "BoolLCG64GeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoolLCG64GeneratorProvider : DiscreteGeneratorProvider<bool>
	{
		[SerializeField] private uint m_InitialState;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private BoolLCG64Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoolLCG64Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => LCG64Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="BoolLCG64Generator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => sharedLCG64Generator;
		}

		/// <summary>
		/// Creates a new <see cref="BoolLCG64Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public BoolLCG64Generator LCG64Generator
		{
			[Pure]
			get => m_DefaultConstructor ? new BoolLCG64Generator() : new BoolLCG64Generator(m_InitialState);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolLCG64Generator"/>.
		/// </summary>
		[NotNull]
		public BoolLCG64Generator sharedLCG64Generator => m_sharedGenerator ??= LCG64Generator;

		/// <summary>
		/// Initial state of <see cref="LCG64"/>. Must be non-zero.
		/// </summary>
		public uint initialState
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_InitialState;
			set
			{
				if (m_InitialState == value)
				{
					return;
				}

				m_InitialState = value;
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
