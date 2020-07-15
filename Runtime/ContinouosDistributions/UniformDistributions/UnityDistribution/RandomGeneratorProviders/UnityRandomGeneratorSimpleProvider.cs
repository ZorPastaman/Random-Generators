// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Provides <see cref="UnityRandomGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.UnityDistributionFolder + "Unity Random Generator Simple Provider",
		fileName = "Unity Random Generator Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class UnityRandomGeneratorSimpleProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private UnityRandomGeneratorSimple m_UnityRandomGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="UnityRandomGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator => new UnityRandomGeneratorSimple();

		/// <summary>
		/// Returns a shared <see cref="UnityRandomGeneratorSimple"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator => m_UnityRandomGenerator;

		/// <summary>
		/// Creates a new <see cref="UnityRandomGeneratorSimple"/> and returns it.
		/// </summary>
		public UnityRandomGeneratorSimple unityRandomGenerator => new UnityRandomGeneratorSimple();

		/// <summary>
		/// Returns a shared <see cref="UnityRandomGeneratorSimple"/>.
		/// </summary>
		public UnityRandomGeneratorSimple sharedUnityRandomGenerator => m_UnityRandomGenerator;
	}
}
