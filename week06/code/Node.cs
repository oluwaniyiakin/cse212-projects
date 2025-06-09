public class Node
{
    public int Data { get; set; }
    public Node? Left { get; private set; }
    public Node? Right { get; private set; }

    public Node(int data)
    {
        Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) // Prevent duplicates
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, do nothing (avoid duplicates)
    }

    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else if (value < Data)
            return Left != null && Left.Contains(value);
        else
            return Right != null && Right.Contains(value);
    }

    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }

    public void TraverseInOrder(List<int> result)
    {
        Left?.TraverseInOrder(result);
        result.Add(Data);
        Right?.TraverseInOrder(result);
    }

    public void TraverseReverseOrder(List<int> result)
    {
        Right?.TraverseReverseOrder(result);
        result.Add(Data);
        Left?.TraverseReverseOrder(result);
    }
}
