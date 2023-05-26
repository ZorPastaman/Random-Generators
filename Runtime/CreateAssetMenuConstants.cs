// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators
{
	public static class CreateAssetMenuConstants
	{
		public const string RandomGeneratorProvidersFolder = "Random Generator Providers/";

		public const string ContinuousDistributionsFolder =
			RandomGeneratorProvidersFolder + "Continuous Distributions/";

		public const string BatesDistributionFolder = ContinuousDistributionsFolder + "Bates Distribution/";
		public const string ExponentialDistributionFolder = ContinuousDistributionsFolder + "Exponential Distribution/";
		public const string ExtremeValueDistributionFolder = ContinuousDistributionsFolder + "Extreme Value Distribution/";
		public const string GammaDistributionFolder = ContinuousDistributionsFolder + "Gamma Distribution/";
		public const string IrwinHallDistributionFolder = ContinuousDistributionsFolder + "Irwin-Hall Distribution/";
		public const string NormalDistributionFolder = ContinuousDistributionsFolder + "Normal Distribution/";
		public const string RejectionDistributionFolder = ContinuousDistributionsFolder + "Rejection Distribution/";
		public const string SharpContinuousDistributionFolder = ContinuousDistributionsFolder + "Sharp Distribution/";
		public const string UnityContinuousDistributionFolder = ContinuousDistributionsFolder + "Unity Distribution/";
		public const string WeibullDistributionFolder = ContinuousDistributionsFolder + "Weibull Distribution/";
		public const string XorShift32ContinuousDistributionFolder = ContinuousDistributionsFolder +
			"XorShift32 Distribution/";
		public const string XorShift64ContinuousDistributionFolder = ContinuousDistributionsFolder +
			"XorShift64 Distribution/";
		public const string XorShift128ContinuousDistributionFolder = ContinuousDistributionsFolder +
			"XorShift128 Distribution/";

		public const string ContinuousModificatorsFolder = ContinuousDistributionsFolder + "Modificators/";

		public const string ContinuousDistributionFiltersFolder = ContinuousDistributionsFolder +
			"Distribution Filters/";

		public const string ContinuousFilteredGeneratorsFolder = ContinuousDistributionFiltersFolder +
			"Filtered Generators/";

		public const string ContinuousFiltersFolder = ContinuousDistributionFiltersFolder + "Filters/";
		public const string AscendantSequenceContinuousFiltersFolder = ContinuousFiltersFolder +
			"Ascendant Sequence Filters/";
		public const string CloseContinuousFiltersFolder = ContinuousFiltersFolder + "Close Filters/";
		public const string DescendantSequenceContinuousFiltersFolder = ContinuousFiltersFolder +
			"Descendant Sequence Filters/";
		public const string GreaterContinuousFiltersFolder = ContinuousFiltersFolder + "Greater Filters/";
		public const string InRangeContinuousFiltersFolder = ContinuousFiltersFolder + "In Range Filters/";
		public const string LessContinuousFiltersFolder = ContinuousFiltersFolder + "Less Filters/";
		public const string LittleDifferenceContinuousFiltersFolder = ContinuousFiltersFolder +
			"Little Difference Filters/";
		public const string NotInRangeContinuousFiltersFolder = ContinuousFiltersFolder + "Not In Range Filters/";

		public const string DiscreteDistributionsFolder = RandomGeneratorProvidersFolder + "Discrete Distributions/";

		public const string BernoulliDistributionFolder = DiscreteDistributionsFolder + "Bernoulli Distribution/";
		public const string BinomialDistributionFolder = DiscreteDistributionsFolder + "Binomial Distribution/";
		public const string GeometricDistributionFolder = DiscreteDistributionsFolder + "Geometric Distribution/";
		public const string NegativeBinomialDistributionFolder = DiscreteDistributionsFolder +
			"Negative Binomial Distribution/";
		public const string PoissonDistributionFolder = DiscreteDistributionsFolder + "Poisson Distribution/";
		public const string SharpDiscreteDistributionFolder = DiscreteDistributionsFolder + "Sharp Distribution/";
		public const string UnityDiscreteDistributionFolder = DiscreteDistributionsFolder + "Unity Distribution/";
		public const string WeightedDistributionFolder = DiscreteDistributionsFolder + "Weighted Distribution/";
		public const string XorShift32DiscreteDistributionFolder = DiscreteDistributionsFolder +
			"XorShift32 Distribution/";
		public const string XorShift64DiscreteDistributionFolder = DiscreteDistributionsFolder +
			"XorShift64 Distribution/";
		public const string XorShift128DiscreteDistributionFolder = DiscreteDistributionsFolder +
			"XorShift128 Distribution/";

		public const string DiscreteModificatorsFolder = DiscreteDistributionsFolder + "Modificators/";

		public const string DiscreteDistributionFiltersFolder = DiscreteDistributionsFolder + "Distribution Filters/";

		public const string DiscreteFilteredGeneratorsFolder = DiscreteDistributionFiltersFolder +
			"Filtered Generators/";

		public const string DiscreteFiltersFolder = DiscreteDistributionFiltersFolder + "Filters/";
		public const string AscendantSequenceDiscreteFiltersFolder = DiscreteFiltersFolder +
			"Ascendant Sequence Filters/";
		public const string CloseDiscreteFiltersFolder = DiscreteFiltersFolder + "Close Filters/";
		public const string DescendantSequenceDiscreteFiltersFolder = DiscreteFiltersFolder +
			"Descendant Sequence Filters/";
		public const string FrequentValueDiscreteFiltersFolder = DiscreteFiltersFolder + "Frequent Value Filters/";
		public const string OppositePatterDiscreteFiltersFolder = DiscreteFiltersFolder + "Opposite Pattern Filters/";
		public const string PairDiscreteFiltersFolder = DiscreteFiltersFolder + "Pair Filters/";
		public const string RepeatingPatternDiscreteFiltersFolder = DiscreteFiltersFolder + "Repeating Pattern Filters/";
		public const string SamePatternDiscreteFiltersFolder = DiscreteFiltersFolder + "Same Pattern Filters/";
		public const string SameSequenceDiscreteFiltersFolder = DiscreteFiltersFolder + "Same Sequence Filters/";

		public const int DistributionOrder = 446;
		public const int ModificatorOrder = 447;
		public const int FilteredGeneratorOrder = 448;
		public const int FilterOrder = 449;
	}
}
