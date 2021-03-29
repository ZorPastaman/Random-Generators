// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="SharpGenerator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SharpContinuousDistributionFolder + "Sharp Generator Provider",
		fileName = "SharpGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class SharpGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private int m_Seed = SharpGeneratorDefaults.DefaultSeed;
#pragma warning restore CS0649

		[NonSerialized] private SharpGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="SharpGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => sharpGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="SharpGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedSharpGenerator;

		/// <summary>
		/// Creates a new <see cref="SharpGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public SharpGenerator sharpGenerator
		{
			[Pure]
			get => new SharpGenerator(m_Seed);
		}

		/// <summary>
		/// Returns a shared <see cref="SharpGenerator"/>.
		/// </summary>
		[NotNull]
		public SharpGenerator sharedSharpGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = sharpGenerator;
				}

				return m_sharedGenerator;
			}
		}

		public int seed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Seed;
			set
			{
				if (m_Seed == value)
				{
					return;
				}

				m_Seed = value;
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
