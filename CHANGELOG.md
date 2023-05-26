# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Extreme Value distribution.

## [1.3.1] - 2021-07-23

### Fixed

- DiscreteGeneratorProviderEditor is not Fallback now. It caused issues with some Custom Editors.

## [1.3.0] - 2021-04-01

### Added

- XorShift128 random engine and wrappers for it.
- Geometric distribution.
- Distributions with setup data (Gamma, Binomial, Geometric, Negative Binomial, Poisson, Weighted)
got special methods and Setup structs that help to compute setup data once and reuse it.
- UnityGeneratorStruct. It's the same thing as UnityGeneratorClass but it's a struct. 
It's used in distributions to mimic IContinuousGenerator.
- FuncGeneratorClass and FuncGeneratorStruct. They are wrappers over Func<float>. They are used
to mimic IContinuousGenerator. The latter is used in distributions.
- AddModificator for continuous and discrete generators.
- MultiplyModificator for continuous generators.
- Weibull distribution.

### Changed

- Unity 2019.4 is now required.
- XorShift algorithms can now jump forward.
- Generators and filters are not serializable anymore.
- UnityGenerator is renamed to UnityGeneratorClass.
- All distributions now use the same method for UnityEngine.Random, Func<float> and IContinuousGenerator
as iid sources.
- Exponential, Gamma, Bernoulli, Binomial, Geometric, Negative Binomial distributions now require
iid sources in range [0, 1). All other distributions can work with iid sources in range [0, 1].

### Removed

- UnityGeneratorSimple.
- All non-standard methods were removed from distributions. Those were methods that modified the result -
use AddModificator or MultiplyModificator to get such a functionality. It affected Bates, Exponential,
Gamma, Irwin-Hall, Binomial, Geometric, Negative Binomial and Poisson distributions.
- Simple generators of mentioned above distributions were removed. Now non-simple generators do the same.

## [1.2.0] - 2020-11-01

### Added

- Exponential distribution.
- XorShift32 random engine and wrappers for it.
- XorShift64 random engine and wrappers for it.

### Changed

- Distributions now use normal epsilon because 
some CPUs don't support standard C# denormal epsilon.

### Fixed

- Binomial distribution became more correct.

## [1.1.0] - 2020-10-07

### Added

- DropSharedGenerator() and DropSharedFilter() methods. They allow to drop a current generator/filter and create a new one on a next call of sharedGenerator/sharedFilter property.
- Editable Weighted generator providers.
- Gamma distribution.
- Negative Binomial distribution.
- Weighted distribution editor.

### Changed

- Marsaglia distribution is renamed to Normal distribution.
- Binomial distribution is rewritten and became much faster.
- Poisson distribution is rewritten to avoid infinite loops.
- Inlining of some methods is changed for performance reasons and more compact assemblies.

### Removed

- Box-Muller distribution. If you use it, start to use Normal distribution.

### Fixed

- NormalGenerator didn't use its parameters.

## [1.0.1] - 2020-09-23

### Changed

- Project structure is changed to shorten paths to avoid long paths.
- AcceptanceRejection... names are renamed to Rejection... names.
- Namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions is shortened to Zor.RandomGenerators.ContinuousDistributions.
- Namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions is shortened to Zor.RandomGenerators.ContinuousDistributions.
- Namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions is shortened to namespace Zor.RandomGenerators.ContinuousDistributions.

## [1.0.0] - 2020-09-19

### Added

#### Distributions
- Random generators infrastructure.
- Random generator providers infrastructure.
- Acceptance-Rejection distribution.
- Bates distribution.
- Bernoulli distribution.
- Binomial distribution.
- Box-Muller distribution.
- Irwin-Hall distribution.
- Marsaglia distribution.
- Sharp random generator wrapper.
- Poisson distribution.
- Unity random generator wrapper.
- Weighted distribution.

#### Modificators
- Modificators infrastructure.
- Clamp modificator.
- Round modificator.

#### Filters
- Filters infrastructure.
- Ascendant Sequence filter.
- Close filter.
- Descendant Sequence filter.
- Greater filter.
- Frequent Value filter.
- In Range filter.
- Less filter.
- Little Difference filter.
- Not In Range filter.
- Opposite Pattern filter.
- Pair filter.
- Repeating Pattern filter.
- Same Pattern filter.
- Same Sequence filter.

#### Assets
- Default Bates generator provider.
- Default Bool Uniform generator provider.
- Default Float Uniform generator provider.
- Default Int Uniform generator provider.
- Default Marsaglia generator provider.

[unreleased]: https://github.com/ZorPastaman/Random-Generators/compare/v1.3.1...HEAD
[1.3.1]: https://github.com/ZorPastaman/Random-Generators/releases/tag/v1.3.1
[1.3.0]: https://github.com/ZorPastaman/Random-Generators/releases/tag/v1.3.0
[1.2.0]: https://github.com/ZorPastaman/Random-Generators/releases/tag/v1.2.0
[1.1.0]: https://github.com/ZorPastaman/Random-Generators/releases/tag/v1.1.0
[1.0.1]: https://github.com/ZorPastaman/Random-Generators/releases/tag/v1.0.1
[1.0.0]: https://github.com/ZorPastaman/Random-Generators/releases/tag/v1.0.0
