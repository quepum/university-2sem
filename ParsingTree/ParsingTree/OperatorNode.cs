namespace ParsingTree;

public class OperatorNode : Node
{
    private readonly char operation;
    private readonly Node left;
    private readonly Node right;

    public OperatorNode(char operation, Node left, Node right)
    {
        if (!"/*-+/".Contains(this.operation))
        {
            throw new Exception(); // написать своё исключение или подумать какое подходит
        }

        this.operation = operation;
        this.left = left;
        this.right = right;
    }

    public override int Evaluate()
    {
        int leftElement = left.Evaluate();
        int rightElement = right.Evaluate();

        switch (operation)
        {
            case '/':
                if (rightElement == 0)
                {
                    throw new Exception(); // ошибка деление на 0
                }

                return leftElement / rightElement;
            case '*':
                return leftElement * rightElement;
            case '-':
                return leftElement - rightElement;
            case '+':
                return leftElement + rightElement;
            default:
                throw new Exception(); // неизвестная операция
        }
    }

    public override string Print()
    {
        return $"( {operation} {left.Print()} {right.Print()} )";
    }
}