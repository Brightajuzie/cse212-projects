public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'. For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan for MultiplesOf(double number, int length):
        // 1. Initialize the result array: Create a new array of doubles with the specified 'length'.
        // 2. Iterate and calculate multiples: Loop from index 0 up to (but not including) 'length'.
        // 3. Formula for multiple: For each index 'i', the multiple is calculated as 'number * (i + 1)'.
        //     When i=0, the multiple is number * 1 (the number itself).
        //     When i=1, the multiple is number * 2.
        //     When i=length-1, the multiple is number * length.
        // 4. Assign to array:Store the calculated multiple at the current index 'i' in the result array.
        // 5. Return the result: After the loop finishes, return the completed array.

        // 1. Initialize the result array
        double[] resultArray = new double[length];

        // 2. Iterate and calculate multiples
        for (int i = 0; i < length; i++)
        {
            // 3. Formula for multiple: number * (i + 1)
            // 4. Assign to array
            resultArray[i] = number * (i + 1);
        }

        // 5. Return the result
        return resultArray;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan for RotateListRight(List<int> data, int amount):
        // The goal is to move the last 'amount' elements to the front of the list.
        // 1. Identify the elements to move: The elements are located from the index 'data.Count - amount' to 'data.Count - 1'.
        // 2. Extract the elements to move: Use the List<T>.GetRange method to create a temporary list containing the last 'amount' elements.
        //     Start index: data.Count - amount
        //     Count: amount
        // 3.  Remove the elements from the end: Use the List<T>.RemoveRange method to delete the last 'amount' elements from the original 'data' list.
        //     Start index: data.Count - amount (Note: since the list shrinks with each removal, this index is correct even after the first element is removed in the loop, but using a single RemoveRange is much cleaner). The *initial* count must be used here.
        //     Count: amount
        // 4.  Insert the elements at the front: Use the List<T>.InsertRange method to place the temporary list of extracted elements at the beginning of the 'data' list (at index 0).

        // 1 & 2. Extract the elements to move (the last 'amount' elements)
        int startIndex = data.Count - amount;
        List<int> elementsToMove = data.GetRange(startIndex, amount);

        // 3. Remove the elements from the end of the original list
        data.RemoveRange(startIndex, amount);

        // 4. Insert the extracted elements at the beginning (index 0) of the list
        data.InsertRange(0, elementsToMove);
    }
}