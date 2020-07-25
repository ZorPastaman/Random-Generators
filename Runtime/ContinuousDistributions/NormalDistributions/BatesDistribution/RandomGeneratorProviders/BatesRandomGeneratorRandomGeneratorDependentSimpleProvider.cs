// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BatesRandomGeneratorRandomGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Random Generator Random Generator Dependent Simple Provider",
		fileName = "Bates Random Generator Random Generator Dependent Simple Provider",
		order = 446
	)]
	public sealed class BatesRandomGeneratorRandomGeneratorDependentSimpleProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_DependedRandomGeneratorProvider;
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;
#pragma warning restore CS0649

		private BatesRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesRandomGeneratorRandomGeneratorDependentSimple{T}"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator
		{
			[Pure]
			get =>
				new BatesRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
					m_DependedRandomGeneratorProvider.randomGenerator, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesRandomGeneratorRandomGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = batesRandomGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="BatesRandomGeneratorRandomGeneratorDependentSimple{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator> batesRandomGenerator
		{
			[Pure]
			get =>
				new BatesRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
					m_DependedRandomGeneratorProvider.randomGenerator, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesRandomGeneratorRandomGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public BatesRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator> sharedBatesRandomGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = batesRandomGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
