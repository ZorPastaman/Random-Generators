// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BoolLCG32Generator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LCG32DiscreteDistributionFolder + "Bool LCG32 Generator Provider",
		fileName = "BoolLCG32GeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoolLCG32GeneratorProvider : DiscreteGeneratorProvider<bool>
	{
		[SerializeField] private uint m_InitialState;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private BoolLCG32Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoolLCG32Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => LCG32Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="BoolLCG32Generator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator => sharedLCG32Generator;

		/// <summary>
		/// Creates a new <see cref="BoolLCG32Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public BoolLCG32Generator LCG32Generator
		{
			[Pure]
			get => m_DefaultConstructor ? new BoolLCG32Generator() : new BoolLCG32Generator(m_InitialState);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolLCG32Generator"/>.
		/// </summary>
		[NotNull]
		public BoolLCG32Generator sharedLCG32Generator => m_sharedGenerator ??= LCG32Generator;

		/// <summary>
		/// Initial state of <see cref="LCG32"/>. Must be non-zero.
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
