public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        
        // Base Case 1: Found the value
        if (value == Data)
        {
            return true;
        }

        // Recursive Step: Decide whether to search left or right
        if (value < Data)
        {
            // Search left
            if (Left is null)
            {
                // Base Case 2: Reached a null node without finding the value
                return false;
            }
            return Left.Contains(value);
        }
        else
        {
            // Search right
            if (Right is null)
            {
                // Base Case 2: Reached a null node without finding the value
                return false;
            }
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        
        // Base Case: If the node is null, the height is -1 (often used for null/empty tree height, 
        // but since this is a method on a non-null Node, the base case below handles leaves).
        
        // Recursive Step: The height of the current node is 1 + the maximum height of its children.

        int leftHeight = Left?.GetHeight() ?? -1;
        int rightHeight = Right?.GetHeight() ?? -1;

        // The height of a leaf node will be 1 + Max(-1, -1) = 0.
        // The height of a single-node tree (root) is 1 + Max(-1, -1) = 0.
        // If the problem defines the height of a single-node tree as 1, the return should be:
        // return Math.Max(leftHeight, rightHeight) + 1;
        // Assuming height of a single-node tree is 0 (number of edges from root to deepest leaf):
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}