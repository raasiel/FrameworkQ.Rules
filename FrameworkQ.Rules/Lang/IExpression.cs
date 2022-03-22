namespace FrameworkQ.Rules.Lang
{
    public interface IExpression
    {
        Variable Resolve();
    }
}