// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Provides <see cref="UnityGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.UnityDistributionFolder + "Unity Generator Simple Provider",
		fileName = "Unity Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class UnityGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private UnityGeneratorSimple m_UnityGenerator;
#pragma warning restore CS0649

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
			[Pure]
			get => m_UnityGenerator;
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
			[Pure]
			get => m_UnityGenerator;
		}
	}
}
