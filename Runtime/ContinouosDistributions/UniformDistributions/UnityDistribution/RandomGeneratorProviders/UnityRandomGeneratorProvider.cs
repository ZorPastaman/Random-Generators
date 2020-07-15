// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Provides <see cref="UnityRandomGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.UnityDistributionFolder + "Unity Random Generator Provider",
		fileName = "Unity Random Generator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class UnityRandomGeneratorProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private UnityRandomGenerator m_UnityRandomGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="UnityRandomGenerator"/> and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator => new UnityRandomGenerator(m_UnityRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="UnityRandomGenerator"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator => m_UnityRandomGenerator;

		/// <summary>
		/// Creates a new <see cref="UnityRandomGenerator"/> and returns it.
		/// </summary>
		public UnityRandomGenerator unityRandomGenerator => new UnityRandomGenerator(m_UnityRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="UnityRandomGenerator"/>.
		/// </summary>
		public UnityRandomGenerator sharedUnityRandomGenerator => m_UnityRandomGenerator;
	}
}
