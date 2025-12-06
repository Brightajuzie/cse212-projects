using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
 public static int SumSquaresRecursive(int n)
  {
        // TODO Start Problem 1
        // Base case: If n is 0 or less, the sum is 0.
  if (n <= 0)
  {
  return 0;
  }

        // Recursive step: Sum of squares up to n is n^2 + SumSquaresRecursive(n-1)
  return (n * n) + SumSquaresRecursive(n - 1);
 }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
  public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
  {
        // TODO Start Problem 2
        // Base case: When the current 'word' reaches the desired 'size'.
 if (word.Length == size)
 {
 results.Add(word);
  return;
  }

        // Recursive step: Iterate through each letter available.
  for (int i = 0; i < letters.Length; i++)
  {
            // Choose: Take the current letter.
 char currentLetter = letters[i];
 
            // Create the remaining letters string (excluding the chosen letter for the next step).
 string remainingLetters = letters.Remove(i, 1);
 
            // Recurse: Call the function with the new word and remaining letters.
  PermutationsChoose(results, remainingLetters, size, word + currentLetter);
  
            // (Unchoose is implicitly handled by the loop and passing copies of strings)
 }
 }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
 public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
  {
        // Initialize memoization dictionary if needed
  if (remember == null)
 {
  remember = new Dictionary<int, decimal>();
  }

        // Check memoization table
 if (remember.ContainsKey(s))
  {
  return remember[s];
  }

        // Base Cases - Optimized slightly by deriving from the formula for s=0, 1, 2.
        // s=0 should actually return 1 if considering starting point (1 way to be at the top if you are already there)
        // but the provided base case states 0, so we adhere to the provided structure:
  if (s == 0)
  return 0; // Adhering to provided base case
  if (s == 1)
  return 1;
  if (s == 2)
  return 2;
  if (s == 3)
  return 4;
            
        // If the problem description's base cases are missing, use this one:
  /*
        if (s < 0) return 0; // Cannot climb a negative number of stairs
        if (s == 0) return 1; // One way to climb 0 stairs (do nothing)
        */

        // TODO Start Problem 3
  
        // Solve using recursion (and pass the memoization dictionary)
  decimal ways = CountWaysToClimb(s - 1, remember) + 
  CountWaysToClimb(s - 2, remember) + 
  CountWaysToClimb(s - 3, remember);

        // Store result in memoization table
 remember[s] = ways;
  return ways;
  }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    /// 
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
 public static void WildcardBinary(string pattern, List<string> results)
  {
        // TODO Start Problem 4
        // Base case: If there are no more wildcards, the pattern is a complete binary string.
 int wildcardIndex = pattern.IndexOf('*');
 
 if (wildcardIndex == -1)
  {
  results.Add(pattern);
  return;
  }

        // Recursive step: Find the first wildcard and replace it with '0' then '1'.
 
        // 1. Replace the wildcard with '0'
  string pattern0 = pattern.Remove(wildcardIndex, 1).Insert(wildcardIndex, "0");
  WildcardBinary(pattern0, results);
  
        // 2. Replace the wildcard with '1'
  string pattern1 = pattern.Remove(wildcardIndex, 1).Insert(wildcardIndex, "1");
 WildcardBinary(pattern1, results);
 }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
  public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
 {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
  if (currPath == null) {
 currPath = new List<ValueTuple<int, int>>();
  }
  
        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        // ADD CODE HERE
        
        // 1. Check Boundary and Wall conditions
 if (!maze.IsSafe(x, y) || maze.IsWall(x, y))
 {
 return;
 }

        // 2. Check for cycles/visited squares
 if (currPath.Contains((x, y)))
 {
 return;
 }

        // 3. Add current square to the path (Choose)
 currPath.Add((x, y));

        // 4. Check Base Case (Found the end)
 if (maze.IsEnd(x, y))
 {
 results.Add(currPath.AsString()); // Use this to add your path to the results array
 currPath.RemoveAt(currPath.Count - 1); // Unchoose for other paths
 return;
 }

        // 5. Recursive Step (Explore neighbors)
        // Try North (y-1)
 SolveMaze(results, maze, x, y - 1, currPath);
        // Try South (y+1)
 SolveMaze(results, maze, x, y + 1, currPath);
        // Try East (x+1)
 SolveMaze(results, maze, x + 1, y, currPath);
        // Try West (x-1)
 SolveMaze(results, maze, x - 1, y, currPath);


        // 6. Backtrack (Unchoose)
 currPath.RemoveAt(currPath.Count - 1);
 }
}