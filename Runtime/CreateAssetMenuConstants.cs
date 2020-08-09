// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators
{
	public static class CreateAssetMenuConstants
	{
		public const string RandomGeneratorProvidersFolder = "Random Generator Providers/";

		public const string ContinuousDistributionsFolder =
			RandomGeneratorProvidersFolder + "Continuous Distributions/";

		public const string IndependentDistributionsFolder =
			ContinuousDistributionsFolder + "Independent Distributions/";
		public const string AcceptanceRejectionDistributionFolder =
			IndependentDistributionsFolder + "Acceptance-Rejection Distribution/";

		public const string NormalDistributionsFolder = ContinuousDistributionsFolder + "Normal Distributions/";
		public const string BatesDistributionFolder = NormalDistributionsFolder + "Bates Distribution/";
		public const string BoxMullerDistributionFolder = NormalDistributionsFolder + "Box-Muller Distibution/";
		public const string IrwinHallDistributionFolder = NormalDistributionsFolder + "Irwin-Hall Distribution/";
		public const string MarsagliaDistributionFolder = NormalDistributionsFolder + "Marsaglia Distribution/";

		public const string UniformDistributionsFolder = ContinuousDistributionsFolder + "Uniform Distributions/";
		public const string UnityDistributionFolder = UniformDistributionsFolder + "Unity Distribution/";

		public const string ContinuousModificatorsFolder = ContinuousDistributionsFolder + "Modificators/";

		public const string DiscreteDistributionsFolder = RandomGeneratorProvidersFolder + "Discrete Distributions/";
		public const string BernoulliDistributionFolder = DiscreteDistributionsFolder + "Bernoulli Distribution/";
		public const string BinomialDistributionFolder = DiscreteDistributionsFolder + "Binomial Distribution/";
		public const string PoissonDistributionFolder = DiscreteDistributionsFolder + "Poisson Distribution/";
		public const string WeightedDistributionFolder = DiscreteDistributionsFolder + "Weighted Distribution/";

		public const string DiscreteModificatorsFolder = DiscreteDistributionsFolder + "Modificators/";

		public const string DiscreteDistributionFiltersFolder = DiscreteDistributionsFolder + "Distribution Filters/";

		public const string DiscreteFilteredGeneratorsFolder = DiscreteDistributionFiltersFolder +
			"Filtered Generators/";

		public const string DiscreteFiltersFolder = DiscreteDistributionFiltersFolder + "Filters/";
		public const string SameSequenceDiscreteFiltersFolder = DiscreteFiltersFolder + "Same Sequence Filters/";

		public const int DistributionOrder = 446;
		public const int ModificatorOrder = 447;
		public const int FilteredGeneratorOrder = 448;
		public const int FilterOrder = 449;
	}
}
