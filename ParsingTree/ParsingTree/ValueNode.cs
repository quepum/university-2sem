namespace ParsingTree;

public class ValueNode(int value) : Node
{
    public override int Evaluate()
    {
        return value;
    }

    public override string Print()
    {
        return value.ToString();
    }
}