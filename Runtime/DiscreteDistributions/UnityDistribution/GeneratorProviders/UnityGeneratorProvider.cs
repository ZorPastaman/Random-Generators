// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.UnityDiscreteDistributionFolder + "Unity Generator Provider",
		fileName = "Unity Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class UnityGeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private UnityGenerator m_UnityGenerator;
#pragma warning restore CS0649

		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new UnityGenerator(m_UnityGenerator);
		}

		public override IDiscreteGenerator<int> sharedGenerator
		{
			[Pure]
			get => m_UnityGenerator;
		}

		[NotNull]
		public UnityGenerator unityGenerator
		{
			[Pure]
			get => new UnityGenerator(m_UnityGenerator);
		}

		[NotNull]
		public UnityGenerator sharedUnityGenerator
		{
			[Pure]
			get => m_UnityGenerator;
		}
	}
}
