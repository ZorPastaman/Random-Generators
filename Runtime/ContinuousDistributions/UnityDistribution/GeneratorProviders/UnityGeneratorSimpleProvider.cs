// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="UnityGeneratorClass"/> for range [0, 1) or [0, 1].
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.UnityContinuousDistributionFolder + "Unity Generator Simple Provider",
		fileName = "UnityGeneratorSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class UnityGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
		[SerializeField, Tooltip("If true, the range of the generator is [0, 1]; otherwise, it's [0, 1).")]
		private bool m_InclusiveOne;

		[NonSerialized] private UnityGeneratorClass m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="UnityGeneratorClass"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => unityGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="UnityGeneratorClass"/> as <see cref="IContinuousGenerator"/>.
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
		/// Creates a new <see cref="UnityGeneratorClass"/> and returns it.
		/// </summary>
		[NotNull]
		public UnityGeneratorClass unityGenerator
		{
			[Pure]
			get => m_InclusiveOne
				? new UnityGeneratorClass(0f, 1f)
				: new UnityGeneratorClass(0f, NumberConstants.SubOne);
		}

		/// <summary>
		/// Returns a shared <see cref="UnityGeneratorClass"/>.
		/// </summary>
		[NotNull]
		public UnityGeneratorClass sharedUnityGenerator
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

		public bool inclusiveOne
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_InclusiveOne;
			set
			{
				if (m_InclusiveOne == value)
				{
					return;
				}

				m_InclusiveOne = value;
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
