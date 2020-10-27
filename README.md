# Random Generators
Random generators for Unity is a collection of random generators, 
different random engines, distributions, modificators and filters.

The library has a useful infrastructure that makes it easy to expand it and add new
distributions, modificators, filters and random generators.

The library is very fast and heap allocation free.

## Installation

This repo is a regular Unity package. You can install it as your project dependency.
More here: https://docs.unity3d.com/Manual/upm-dependencies.html.

## Usage

1. Create a provider from **Assets/Create/Random Generator Providers/** or choose one of
pre-made providers among 
**DefaultBoolUniformGeneratorProvider**, **DefaultIntUniformGeneratorProvider**,
**DefaultFloatUniformGeneratorProvider**, **DefaultNormalGeneratorProvider** and
**DefaultBatesGeneratorProvider**.
2. Add **ContinuousGeneratorProviderReference** for continuous distributions or
**DiscreteGeneratorProviderReference** for discrete distributions as a serialize field
into your component.
3. Link a selected provider into a right provider reference. Toggle on/off Shared.
If Shared is on, a generator is created once and reused by all requesters.
If Shared is off, a new generator is created for every requester.
4. In your script, call **ContinuousGeneratorProviderReference.generator** or
**DiscreteGeneratorProviderReference.GetGenerator<T>()** and cache the result.
They return a **IContinuousGenerator** or **IDiscreteGenerator<T>** that generate
a random value.
5. Call **Generate()** in a gotten generator to get a random value that corresponds to
a selected distribution.

Also, you can create your own infrastructure. Every part of this library is public and
available separately from other parts.

## Parts

### Random Engines

Random engines are algorithms in structs that generate pseudo-random values.

##### List of random engines

- [XorShift32](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/RandomEngines/XorShift/XorShift32.cs) -
[Wikipedia](https://en.wikipedia.org/wiki/Xorshift)

### Random Generators

Random generators use random engines (custom or pre-built in Unity)
to generate pseudo-random values corresponding to a distribution.
They may simply wrap random engines as well.
They consist of distributions, generators and generator providers.

#### Distributions

Distributions are just algorithms in static classes that return a random value(s).
They usually require an independent and identically distributed random generator.
By default, Unity generator is used as such a generator. 
Also, the distributions support `Func<float>` and `IContinuousGenerator` as an iid random generator.

#### Generators

Generators are standard c# classes that implement [IContinuousGenerator](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/ContinuousDistributions/IContinuousGenerator.cs)
or [IDiscreteGenerator<T>](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/DiscreteDistributions/IDiscreteGenerator.cs)
and wrap one of the methods of the distributions.

#### Generator Providers

Generator providers are scriptable objects and can be linked to a serialize field in Unity components.
They wrap generators and provide unique and shared instances of them.

##### List of continuous generator algorithms

- [Bates](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/BatesDistribution) -
[Wikipedia](https://en.wikipedia.org/wiki/Bates_distribution);
- [Exponential](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/ExponentialDistribution) -
[Wikipedia](https://en.wikipedia.org/wiki/Exponential_distribution);
- [Gamma](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/GammaDistribution) -
[Wikipedia](https://en.wikipedia.org/wiki/Gamma_distribution);
- [Irwin-Hall](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/IrwinHallDistribution) -
[Wikipedia](https://en.wikipedia.org/wiki/Irwin%E2%80%93Hall_distribution);
- [Normal](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/NormalDistribution) -
[Wikipedia](https://en.wikipedia.org/wiki/Normal_distribution);
- [Rejection](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/RejectionDistribution) -
[Wikipedia](https://en.wikipedia.org/wiki/Rejection_sampling);
- [C# Random Generator Wrapper](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/SharpDistribution) -
[Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.random?view=netframework-4.8);
- [Unity Random Generator Wrapper](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/UnityDistribution) -
[Unity Docs](https://docs.unity3d.com/ScriptReference/Random.html).
- [XorShift32 Random Generator Wrapper](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/XorShift32Distribution)

##### List of discrete generator algorithms

- [Bernoulli](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/BernoulliDistribution) -
[Wikipedia](https://en.wikipedia.org/wiki/Bernoulli_distribution);
- [Binomial](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/BinomialDistribution) -
[Wikipedia](https://en.wikipedia.org/wiki/Binomial_distribution);
- [Negative Binomial](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/NegativeBinomialDistribution) -
[Wikipedia](https://en.wikipedia.org/wiki/Negative_binomial_distribution);
- [Poisson](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/PoissonDistribution) -
[Wikipedia](https://en.wikipedia.org/wiki/Poisson_distribution);
- [C# Random Generator Wrapper](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/SharpDistribution) -
[Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.random?view=netframework-4.8);
- [Unity Random Generator Wrapper](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/UnityDistribution) -
[Unity Docs](https://docs.unity3d.com/ScriptReference/Random.html);
- [Weighted](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/WeightedDistribution) -
distribution where every value has a weight and its probability is a ratio of its weight to a sum of all weights.
- [XorShift32 Random Generator Wrapper](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/XorShift32Distribution)

### Random modificators

There are different modificators in this library. They modify results of generators and mimic them.
Modificators has providers as random generators.

#### Modificators

Modificators are standard c# classes that implement [IContinuousGenerator](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/ContinuousDistributions/IContinuousGenerator.cs)
or [IDiscreteGenerator<T>](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/DiscreteDistributions/IDiscreteGenerator.cs)
but they are not actually generators, they take a generated value from a depended generator, modify it somehow and return a result.

#### Modificator Providers

Modificator providers are scriptable objects and can be linked to a serialize field in Unity components.
They wrap modificators and provide unique and shared instances of them.

##### List of continuous modificators

- [Clamp](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/DistributionModificators/Clamp) -
a continuous value is clamped between specified minimum and maximum values;
- [Round](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/DistributionModificators/Round) -
a continuous value is rounded to a nearest integer.

##### List of discrete modificators

- [Clamp](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionModificators/Clamp) -
a discrete value is clamped between specified minimum and maximum values;
- [Round to Int](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionModificators/Round) -
a continuous value is rounded to a nearest integer and returned as a discrete value.

### Random filters

For usual people random values may look like non-random. Because of that we need to filter results of random generators
and regenerate them if a filter forbids a new value.

#### Filters

Filters are algorithms in static classes that check if a new generated value corresponds to their rules.
They usually forbid certain sequences of random generated values.

#### Filter Wrappers

Filter wrappers are standard c# classes that implement [IContinuousFilter](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/ContinuousDistributions/DistributionFilters/IContinuousFilter.cs)
or [IDiscreteFilter](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/DiscreteDistributions/DistributionFilters/IDiscreteFilter.cs)
and wrap one of the methods of filters.

#### Filter Providers

Filter providers are scriptable objects and can be linked to a serialize field in Unity components.
They wrap filter wrappers and provide unique and shared instances of them.

#### Filtered Generators

Filtered generators are standard c# classes that implement [IContinuousFilter](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/ContinuousDistributions/DistributionFilters/IContinuousFilter.cs)
or [IDiscreteFilter](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/DiscreteDistributions/DistributionFilters/IDiscreteFilter.cs).
They take a generated value from a depended generator and check that value with filters.
If at least one filter doesn't approve a new value, it's regenerated and checked again.

#### Filtered Generator Providers

Filtered generator providers are scriptable objects and can be linked to a serialize field in Unity components.
They wrap filtered generators and provide unique and shared instances of them.

##### List of continuous filters

- [Ascendant Sequence](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/DistributionFilters/AscendantSequenceFilters) - 
checks if a value continues an ascendant sequence and it needs to be regenerated;
- [Close](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/DistributionFilters/CloseFilters) -
checks if a value continues a sequence where every value is close enough to a reference value and needs to be regenerated;
- [Descendant Sequence](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/DistributionFilters/DescendantSequenceFilters) -
checks if a value continues a descendant sequence and it needs to be regenerated;
- [Greater](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/DistributionFilters/GreaterFilters) -
checks if a value continues a sequence where every value is greater than a reference value and needs to be regenerated;
- [In Range](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/DistributionFilters/InRangeFilters) -
checks if a value continues a sequence where every value is in range between the minimum and maximum and needs to be regenerated;
- [Less](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/DistributionFilters/LessFilters) -
checks if a value continues a sequence where every value is less than a reference value and needs to be regenerated;
- [Little Difference](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/DistributionFilters/LittleDifferenceFilters) -
checks if a value continues a sequence where consecutive elements differ by less than a required difference and needs to be regenerated;
- [Not In Range](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/ContinuousDistributions/DistributionFilters/NotInRangeFilters) -
checks if a value continues a sequence where every value is in range between the minimum and maximum and needs to be regenerated.

##### List of discrete filters

- [Ascendant Sequence](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionFilters/AscendantSequenceFilters) -
checks if a value continues an ascendant sequence and it needs to be regenerated;
- [Close](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionFilters/CloseFilters) -
checks if a value continues a sequence where every value is close enough to a reference value and needs to be regenerated;
- [Descendant Sequence](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionFilters/DescendantSequenceFilters) -
checks if a value continues a descendant sequence and it needs to be regenerated;
- [Frequent Value](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionFilters/FrequentValueFilters) -
checks if a value is contained in a sequence more than allowed times and needs to be regenerated;
- [Opposite Pattern](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionFilters/OppositePatternFilters) -
checks if a value forms a pattern opposite to a previous pattern and needs to be regenerated;
- [Pair](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionFilters/PairFilters) -
Checks if a value is contained in a sequence some elements before and needs to be regenerated;
- [Repeating Pattern](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionFilters/RepeatingPatternFilters) -
checks if a new value forms a pattern the same to a pattern some elements before and needs to be regenerated;
- [Same Pattern](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionFilters/SamePatternFilters) -
checks if a value forms the same pattern in a sequence as a pattern before and needs to be regenerated;
- [Same Sequence](https://github.com/ZorPastaman/Random-Generators/tree/master/Runtime/DiscreteDistributions/DistributionFilters/SameSequenceFilters) -
checks if a value continues a sequence where every value is the same and needs to be regenerated.

### References

References are serializable structs that wrap an access to unique and shared generators or filters from their providers.
All the references require a link to a provider. Also, they have a toggle **Shared**. 
If it's on, a reference returns a shared generator or filter. If it's off, a reference returns a unique generator or filter.

##### List of references

- [Continuous Generator Provider Reference](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/ContinuousDistributions/ContinuousGeneratorProviderReference.cs);
- [Discrete Generator Provider Reference](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/DiscreteDistributions/DiscreteGeneratorProviderReference.cs);
- [Continuous Filter Provider Reference](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/ContinuousDistributions/DistributionFilters/ContinuousFilterProviderReference.cs);
- [Discrete Filter Provider Reference](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/DiscreteDistributions/DistributionFilters/DiscreteFilterProviderReference.cs).

### Property drawers

- [Require Discrete Generator](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/PropertyDrawerAttributes/RequireDiscreteGenerator.cs) -
doesn't allow to set a generator with a wrong type into 
[Discrete Generator Provider Reference](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/DiscreteDistributions/DiscreteGeneratorProviderReference.cs);
- [Require Discrete Filter](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/PropertyDrawerAttributes/RequireDiscreteFilter.cs) -
doesn't allow to set a filter with a wrong type into
[Discrete Filter Provider Reference](https://github.com/ZorPastaman/Random-Generators/blob/master/Runtime/DiscreteDistributions/DistributionFilters/DiscreteFilterProviderReference.cs).
