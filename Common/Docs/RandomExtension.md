# RandomExtension

This is an extension class for the Random object. It has the following methods:

## NextDouble
### double NextDouble(this Random random, double min, double max)

Gets a random double between the two specified numbers.

*Parameters*

* min: Minimum random number.
* max: Maximum randon number.

## NextDoubleInRange
### double NextDoubleInRange(this Random random, double range)

Gets a random double from 0 within +/- the supplied range.

*Parameters*

* range: The range above and below 0 to generate the number.

### double NextDoubleInRange(this Random random, double start, double range)

Gets a random double from the start value within +/- the supplied range.

*Parameters*

* start: The number the range is starts from.
* range: The range above and below the start to generate the number.

## NextLong
### long NextLong(this Random random, long min, long max)

Gets a random long between the two specified numbers.

*Parameters*

* min: Minimum random number.
* max: Maximum randon number.
