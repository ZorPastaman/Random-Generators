# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- DropSharedGenerator() and DropSharedFilter() methods. They allow to drop a current generator/filter and create a new one on a next call of sharedGenerator/sharedFilter property.
- Editable Weighted generator providers.
- Negative Binomial distribution.

### Changed

- Marsaglia distribution is renamed to Normal distribution.
- Binomial distribution is rewritten and became much faster.

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

[unreleased]: https://github.com/ZorPastaman/Random-Generators/compare/v1.0.1...HEAD
[1.0.1]: https://github.com/ZorPastaman/Random-Generators/releases/tag/v1.0.1
[1.0.0]: https://github.com/ZorPastaman/Random-Generators/releases/tag/v1.0.0
