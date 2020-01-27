# Introduction 
Some fun with genetic algorithms. We will try to find the solution to a simple formula, like:

> **a** + **2b** + **3c** + **4d** = **[ Target Number ]**

In the process hopefully we will fall into many of the pitfalls of genetic algorithms to gain experience in the field.

# Getting Started
## Installation process
Just clone the repository, open the solution file in VS and you are ready to go. (Built, run tests, etc.)

## Software dependencies
- Visual Studio 2019
- .NET Core 3.1
- NuGet Package Manager

## Latest releases

| Date       | Version     | Summary                                                          |
|------------|-------------|------------------------------------------------------------------|
| 2020-01-27 | 1.0         | First working version. The most simple version of the algorithm. |

# Build and Test
Open the solution in Visual Studio and hit build/run.

# Run
When launched without parameters the application will show the help:
```
[Usage]

   TestApplication.exe <target number>

[Example]

   TestApplication.exe 30
```
The target number is what the formula should be equal to:

> **a** + **2b** + **3c** + **4d** = **[ Target Number ]**

Example:
```
TestApplication.exe 67
```

## Example output
```
In this application we will try to generate the possible (approximating) solution to the following function:

   a + 2b + 3c + 4d = 67

Launching algorithm.
Press [ESC] to stop.
324 iteration, found specimens: 10.
Done.

-30 + (2 * 19) + (3 * 29) + (4 * -7) = -30 + 38 + 87 + -28 = 67.
-30 + (2 * 22) + (3 * 27) + (4 * -7) = -30 + 44 + 81 + -28 = 67.
-30 + (2 * 25) + (3 * 25) + (4 * -7) = -30 + 50 + 75 + -28 = 67.
-30 + (2 * 28) + (3 * 23) + (4 * -7) = -30 + 56 + 69 + -28 = 67.
-29 + (2 * 17) + (3 * 30) + (4 * -7) = -29 + 34 + 90 + -28 = 67.
-29 + (2 * 20) + (3 * 28) + (4 * -7) = -29 + 40 + 84 + -28 = 67.
-29 + (2 * 23) + (3 * 26) + (4 * -7) = -29 + 46 + 78 + -28 = 67.
-29 + (2 * 26) + (3 * 24) + (4 * -7) = -29 + 52 + 72 + -28 = 67.
-29 + (2 * 29) + (3 * 22) + (4 * -7) = -29 + 58 + 66 + -28 = 67.
-28 + (2 * 18) + (3 * 29) + (4 * -7) = -28 + 36 + 87 + -28 = 67.
```
# Algorithm
## Main concept
The main concept of the algorithm:

1. **Generate a population randomly**:
An initial population will be generated with random properties.

1. **Calculate fitness of every specimen.**
Every specimens' fitness will be calculated and stored.

1. **Iteration** *(Until [ESC] pressed)*
   
   1. **Collect acceptable speciemens**:
   The acceptable specimens are collected. Maybe we were lucky and already found some acceptable solutions.

   1. **Natural selection**:
   Hybridize specimens based on their fitness. Specimens with higher fitness will have higher probability of hybridization. Algorithm will change every specimen with exactly one offspring.[1]
   
   1. **Mutation**:
   With a given probability of mutation the algorithm changes some properties in the population. The algorithm will take the number of population multiplied with the number of properties and randomly select the given percentage to modify.
   > *Example:*
   >
   > 100 specimens * 4 properties = 400
   >
   > Randomly chosen: 3, 6, 7
   >
   > ```
   > Example: 2 specimens with 4-4 properties:
   > 
   > |     1st     |     2nd     |         ...
   > | [ A B C D ] | [ A B C D ] |         ...
   > |   1 2 3 4   |   5 6 7 8   |         ...
   > |       *     |     * *     |         ...
   >```
   > So these will be changed:
   >```
   > (1st).C := random(-31, 30)
   > (2nd).B := random(-31, 30)
   > (2nd).C := random(-31, 30)
   > ```
   
   1. **Fitness check**:
   The fitness of every newly born and mutated offspring will be calculated and stored.

## Problems
This algorithm is not working all the time. Sometimes it will find hundreds of solutions in a few iterations, sometimes just a few, sometimes 0. It really depends on the randomly generated initial population. To make it better there are options how to improve:
1. **Better start population**: Try to generate an initial population which is not that random and will have a great variance so the hybridization process won't stuck in a ditch.
1. **Stronger mutation**: Make the mutation stronger with bigger probability.
1. **Strong mutation after stabilization**: Leave the mutation for vanilla cases but if the algorithm seems to stabilize (new items are not found anymore or just a few new found in every iteration) then mutate the population's greater percentage.
1. **Cause catastrophe**: As in nature (like 65 million years ago) introduce a catastrophe which will completely remove majority of the population and regenerate it if the algorithm seems to stabilize.
1. **Combination**: Combine the previous ideas.

# Contribute
No contribution is needed yet, this solution is just for fun, but if you find some bugs or wrongly phased parts then you can create a branch and send a pull request, I *may* take a look at it.

# References
- [Roulette Wheel selection procedure (StackOverflow.com)][1]
- [Hermawanto, Denny (2020). Genetic Algorithm for Solving Simple Mathematical Equality Problem][2]

[1]: https://stackoverflow.com/questions/10765660/roulette-wheel-selection-procedure
[2]: https://arxiv.org/ftp/arxiv/papers/1308/1308.4675.pdf
