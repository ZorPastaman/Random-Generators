﻿// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift128GeneratorRanged"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift128ContinuousDistributionFolder +
			"XorShift128 Generator Ranged Simple Provider",
		fileName = "XorShift128 Generator Ranged Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift128GeneratorRangedSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min = XorShift128Defaults.DefaultMin;
		[SerializeField] private float m_Max = XorShift128Defaults.DefaultMax;
#pragma warning restore CS0649

		[NonSerialized] private XorShift128GeneratorRanged m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift128GeneratorRanged"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new XorShift128GeneratorRanged(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift128GeneratorRanged"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
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
		/// Creates a new <see cref="XorShift128GeneratorRanged"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift128GeneratorRanged xorShift128Generator
		{
			[Pure]
			get => new XorShift128GeneratorRanged(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift128GeneratorRanged"/>.
		/// </summary>
		[NotNull]
		public XorShift128GeneratorRanged sharedXorShift128Generator
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
