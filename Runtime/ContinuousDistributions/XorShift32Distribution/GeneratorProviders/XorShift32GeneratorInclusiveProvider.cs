// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift32GeneratorInclusive"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift32ContinuousDistributionFolder +
			"XorShift32 Generator Inclusive Provider",
		fileName = "XorShift32GeneratorInclusiveProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift32GeneratorInclusiveProvider : ContinuousGeneratorProvider
	{
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialState = XorShift32Defaults.InitialState;

		private XorShift32GeneratorInclusive m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift32GeneratorInclusive"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift32Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift32GeneratorInclusive"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift32Generator;

		/// <summary>
		/// Creates a new <see cref="XorShift32GeneratorInclusive"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift32GeneratorInclusive xorShift32Generator
		{
			[Pure]
			get => new XorShift32GeneratorInclusive(m_InitialState);
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift32GeneratorInclusive"/>.
		/// </summary>
		[NotNull]
		public XorShift32GeneratorInclusive sharedXorShift32Generator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift32Generator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Initial state of <see cref="XorShift32"/>. Must be non-zero.
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
