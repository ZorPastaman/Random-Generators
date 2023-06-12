// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="LCG32Generator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LCG32DistributionFolder + "LCG32 Generator Provider",
		fileName = "LCG32GeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class LCG32GeneratorProvider : ContinuousGeneratorProvider
	{
		[SerializeField] private uint m_InitialState;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private LCG32Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="LCG32Generator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			get => lcg32Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="LCG32Generator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedLCG32Generator;

		/// <summary>
		/// Creates a new <see cref="LCG32Generator"/> and returns it.
		/// </summary>
		public LCG32Generator lcg32Generator
		{
			get => m_DefaultConstructor ? new LCG32Generator() : new LCG32Generator(m_InitialState);
		}

		/// <summary>
		/// Returns a shared <see cref="LCG32Generator"/>.
		/// </summary>
		public LCG32Generator sharedLCG32Generator => m_sharedGenerator ??= lcg32Generator;

		public uint initialState
		{
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

		/// <inheritdoc/>
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
