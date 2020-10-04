// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="UnityGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.UnityContinuousDistributionFolder + "Unity Generator Simple Provider",
		fileName = "Unity Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class UnityGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
		[NonSerialized] private UnityGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="UnityGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new UnityGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="UnityGeneratorSimple"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = unityGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="UnityGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public UnityGeneratorSimple unityGenerator
		{
			[Pure]
			get => new UnityGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="UnityGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public UnityGeneratorSimple sharedUnityGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = unityGenerator;
				}

				return m_sharedGenerator;
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
