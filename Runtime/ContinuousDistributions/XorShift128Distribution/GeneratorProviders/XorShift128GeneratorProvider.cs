// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift128Generator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift128ContinuousDistributionFolder + "XorShift128 Generator Provider",
		fileName = "XorShift128GeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift128GeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialStateA = XorShift128Defaults.InitialStateA;
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialStateB = XorShift128Defaults.InitialStateB;
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialStateC = XorShift128Defaults.InitialStateC;
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialStateD = XorShift128Defaults.InitialStateD;
#pragma warning restore CS0649

		[NonSerialized] private XorShift128Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift128Generator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift128Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift128Generator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift128Generator;

		/// <summary>
		/// Creates a new <see cref="XorShift128Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift128Generator xorShift128Generator
		{
			[Pure]
			get => new XorShift128Generator(m_InitialStateA, m_InitialStateB, m_InitialStateC, m_InitialStateD);
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift128Generator"/>.
		/// </summary>
		[NotNull]
		public XorShift128Generator sharedXorShift128Generator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift128Generator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Initial state of <see cref="XorShift128"/>. Every item must be non-zero.
		/// </summary>
		public (uint, uint, uint, uint) initialState
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => (m_InitialStateA, m_InitialStateB, m_InitialStateC, m_InitialStateD);
			set
			{
				if (m_InitialStateA == value.Item1 & m_InitialStateB == value.Item2 &
					m_InitialStateC == value.Item3 & m_InitialStateD == value.Item4)
				{
					return;
				}

				m_InitialStateA = value.Item1;
				m_InitialStateB = value.Item2;
				m_InitialStateC = value.Item3;
				m_InitialStateD = value.Item4;

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
