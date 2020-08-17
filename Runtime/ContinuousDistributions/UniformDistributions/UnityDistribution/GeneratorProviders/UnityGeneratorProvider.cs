// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Provides <see cref="UnityGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.UnityContinuousDistributionFolder + "Unity Generator Provider",
		fileName = "Unity Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class UnityGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private UnityGenerator m_UnityGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="UnityGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new UnityGenerator(m_UnityGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="UnityGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get => m_UnityGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="UnityGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public UnityGenerator unityGenerator
		{
			[Pure]
			get => new UnityGenerator(m_UnityGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="UnityGenerator"/>.
		/// </summary>
		[NotNull]
		public UnityGenerator sharedUnityGenerator
		{
			[Pure]
			get => m_UnityGenerator;
		}
	}
}
