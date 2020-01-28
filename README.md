# Introduction 
Some fun with genetic algorithms. We will try to find the solution to a simple formula, like:

> **sin(x<sup>2</sup> + y<sup>2</sup>) = 0**

In this case we are not searching for exact solutions, we are okay with approximations too. In the end the found points will be plotted to an image and shown.[3]

In the process hopefully we will fall into many of the pitfalls of genetic algorithms to gain experience in the field.

# Getting Started
## Installation process
Just clone the repository, open the solution file in VS and you are ready to go. (Built, run tests, etc.)

## Software dependencies
- Visual Studio 2019
- .NET Core 3.1
- NuGet Package Manager

## Latest releases

| Date       | Version     | Summary                                                                           |
|------------|-------------|-----------------------------------------------------------------------------------|
| 2020-01-28 | 2.0         | Algorithm remains the same, working with more complex function and approximation. |
| 2020-01-27 | 1.0         | First working version. The most simple version of the algorithm.                  |

# Build and Test
Open the solution in Visual Studio and hit build/run.

# Run
Launch the application without parameters.

## Example output
```
In this application we will try to generate the possible (approximating) solution to the following function:

   sin(x² + y²) = 0

Launching algorithm.
Press [ESC] to stop.
19231 iteration, found specimens: 4599.
Done.

```
Generated image:
![alt text](https://raw.githubusercontent.com/poseen/GeneticAlgorithmPlayground/master/doc/exampleOutput.bmp "Example output")

# Algorithm
## Main concept
The main concept of the algorithm:

![alt text](https://raw.githubusercontent.com/poseen/GeneticAlgorithmPlayground/master/doc/algorithm.png "Algorithm flowchart")

### Generate population
(Initialization) The algorithm will generate a fixed sized population (100) with random properties and will keep it at that level.

### Calculate fitness
(Iteration starts here.) The specimens' fitness will be re-calculated and stored in the beginning of every iteration.

### Collect acceptable speciemens
The acceptable specimens are collected. The acceptance criteria may be an exact equality check against the fitness value (when we are searching for specimens which totally satisfy our requirement) or we can define a tolerance if we are satisfied with some estimating result.

### Selection and Hybridization
Hybridize specimens based on their fitness. Specimens with higher fitness will have higher probability of hybridization. Algorithm will change every specimen with exactly one offspring, therefore will keep the size of population constant.

The generation of hybridization pairs are made with the roulette-algorithm[1]. It may happen that a specimen will hybridize with itself.
   
### Mutation
With a given probability of mutation the algorithm changes some properties in the population. The algorithm will take the number of population multiplied with the number of properties and randomly select the given percentage to modify.
*Example:*
4 specimens * 4 properties = 16

 Therefore we have to shuffle the numbers between **0** and **15**.

 Let's assume the first 4 items in the shuffled list of numbers: 2, 5, 6, 15.

 P<sub>0</sub>...P<sub>3</sub> represents the properties of the specimens, and let's put the specimens in order and assign numbers to the propertiesin the following manner:

 ![alt text](https://raw.githubusercontent.com/poseen/GeneticAlgorithmPlayground/master/doc/mutation.png "Mutation example")

Formula to be used:
```
[generated num.] mod [# of properties] = [Property ID]
[generated num.] div [# of properties] = [Specimen ID]
```

| Generated number | Specimen ID | Property ID |
|:----------------:|:-----------:|:-----------:|
| **2**            | 0           | 2           |
| **5**            | 1           | 1           |
| **6**            | 1           | 2           |
| **15**           | 3           | 3           |

Therefore the following mutation will happen:
 - Specimen<sub>0</sub>.P<sub>2</sub> = random(-30, 31)
 - Specimen<sub>1</sub>.P<sub>1</sub> = random(-30, 31)
 - Specimen<sub>1</sub>.P<sub>2</sub> = random(-30, 31)
 - Specimen<sub>3</sub>.P<sub>3</sub> = random(-30, 31)

### Terminal Condition
This algorithm is stable in the perspective of memory and CPU usage because the population is kept on a constant level. Therefore the algorithm may run as long as we would like, but we can define any terminal condition:
- Run algorithm until key pressed
- We find the first accetpable specimen
- We find a given quantity of specimens
- Algorithm is stabilizing and can't find more specimens or just slowly

### Return found specimens
We return the found specimens.

# Problems with this algorithm concept
This algorithm is not working well all the time. Sometimes it will find hundreds of solutions in a few iterations, sometimes just a few, sometimes 0. It really depends on the randomly generated initial population, and the mutation probability. To make it better there are options how to improve:

## Better start population
It may happen the start population contains wrong specimens which won't be able to hybridize to generate better offsprings. You will see this when from the beginning the algorithm doesn't find enough (or any) acceptable specimens. To solve this you may try to implement a better population generator which will generate specimens which will better suite the hybridization and will contain some genes which will make their way to the acceptable specimens.

## Stronger mutation
Maybe the mutation isn't strong or isn't probable enough. Make the mutation stronger with bigger probability.

## Strong mutation after stabilization
Leave the mutation for vanilla cases but if the algorithm seems to stabilize (new items are not found anymore or just a few new found in every 10th or 100th of iterations) then mutate the population's greater percentage with stronger mutation.

## Catastrophe
As in nature (like 65 million years ago) catastrophes happen which will drastically change the outcome of evolution. So an idea can be to introduce a catastrophe which will completely remove majority of the population and regenerate it if the algorithm seems to stabilize.

## Combination
Combine the previous ideas.

# Contribute
No contribution is needed yet, this solution is just for fun, but if you find some bugs or wrongly phased parts then you can create a branch and send a pull request, I *may* take a look at it.

# References
- [Roulette Wheel selection procedure (StackOverflow.com)][1]
- [Hermawanto, Denny (2020). Genetic Algorithm for Solving Simple Mathematical Equality Problem][2]
- [The sin(x<sup>2</sup> + y<sup>2</sup>) function][3]

[1]: https://stackoverflow.com/questions/10765660/roulette-wheel-selection-procedure
[2]: https://arxiv.org/ftp/arxiv/papers/1308/1308.4675.pdf
[3]: https://www.google.com/search?safe=active&source=hp&ei=5XkwXpDkD7mGwPAPzKa7wA4&q=sin%28x%5E2%2By%5E2%29&oq=sin%28x%5E2%2By%5E2%29&gs_l=psy-ab.3..0i19l5j0i30i19l2j0i10i30i19j0i5i30i19l2.1548.10162..10481...1.0..1.100.1109.12j1......0....1..gws-wiz.......0i131j0j0i3j0i30j0i10i30j0i8i30j0i8i10i30.SVLfJELg2vY&ved=0ahUKEwjQ6un_8qbnAhU5AxAIHUzTDugQ4dUDCAY&uact=5
