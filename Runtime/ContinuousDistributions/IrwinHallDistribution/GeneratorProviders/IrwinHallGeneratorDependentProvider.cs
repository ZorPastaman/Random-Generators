// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="IrwinHallGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.IrwinHallDistributionFolder + "Irwin-Hall Generator Dependent Provider",
		fileName = "IrwinHallGeneratorDependentProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class IrwinHallGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1].")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, Tooltip("How many independent and identically distributed random values are generated.")]
		private byte m_Iids = IrwinHallDistribution.DefaultIids;
#pragma warning restore CS0649

		private IrwinHallGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="IrwinHallGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => irwinHallGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGeneratorDependent{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedIrwinHallGenerator;

		/// <summary>
		/// Creates a new <see cref="IrwinHallGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public IrwinHallGeneratorDependent<IContinuousGenerator> irwinHallGenerator
		{
			[Pure]
			get => new IrwinHallGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public IrwinHallGeneratorDependent<IContinuousGenerator> sharedIrwinHallGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = irwinHallGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		public ContinuousGeneratorProviderReference dependedGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DependedGeneratorProvider;
			set
			{
				if (m_DependedGeneratorProvider == value)
				{
					return;
				}

				m_DependedGeneratorProvider = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// How many independent and identically distributed random values are generated.
		/// </summary>
		public byte iids
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Iids;
			set
			{
				if (m_Iids == value)
				{
					return;
				}

				m_Iids = value;
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
