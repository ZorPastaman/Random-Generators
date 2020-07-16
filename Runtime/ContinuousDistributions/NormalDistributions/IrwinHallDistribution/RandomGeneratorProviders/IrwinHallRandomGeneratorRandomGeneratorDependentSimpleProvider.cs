// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="IrwinHallRandomGeneratorRandomGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.IrwinHallDistributionFolder + "Irwin-Hall Random Generator Random Generator Dependent Simple Provider",
		fileName = "Irwin-Hall Random Generator Random Generator Dependent Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class IrwinHallRandomGeneratorRandomGeneratorDependentSimpleProvider :
		ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_DependedRandomGenerator;
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids;
#pragma warning restore CS0649

		private IrwinHallRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator> m_sharedRandomGenerator;

		/// <summary>
		/// Creates a new <see cref="IrwinHallRandomGeneratorRandomGeneratorDependentSimple{T}"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator =>
			new IrwinHallRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
				m_DependedRandomGenerator.randomGenerator, m_Iids);

		/// <summary>
		/// Returns a shared <see cref="IrwinHallRandomGeneratorRandomGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			get
			{
				if (m_sharedRandomGenerator == null)
				{
					m_sharedRandomGenerator = irwinHallRandomGenerator;
				}

				return m_sharedRandomGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="IrwinHallRandomGeneratorRandomGeneratorDependentSimple{T}"/> and returns it.
		/// </summary>
		public IrwinHallRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator> irwinHallRandomGenerator =>
			new IrwinHallRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
				m_DependedRandomGenerator.randomGenerator, m_Iids);

		/// <summary>
		/// Returns a shared <see cref="IrwinHallRandomGeneratorRandomGeneratorDependentSimple{T}"/>.
		/// </summary>
		public IrwinHallRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator> sharedIrwinHallRandomGenerator
		{
			get
			{
				if (m_sharedRandomGenerator == null)
				{
					m_sharedRandomGenerator = irwinHallRandomGenerator;
				}

				return m_sharedRandomGenerator;
			}
		}
	}
}
