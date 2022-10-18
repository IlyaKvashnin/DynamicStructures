public class Trees
{
    public static DecisionQuery MainDecisionTree()
{
    //Decision 4
    var creditBranch = new DecisionQuery
    {
        Title = "Use credit card",
        Test = (client) => client.UsesCreditCard,
        Positive = new DecisionResult { Result = true },
        Negative = new DecisionResult { Result = false }
    };

    //Decision 3
    var experienceBranch = new DecisionQuery
    {
        Title = "Have more than 3 years experience",
        Test = (client) => client.YearsInJob > 3,
        Positive = creditBranch,
        Negative = new DecisionResult { Result = false }
    };


    //Decision 2
    var moneyBranch = new DecisionQuery
    {
        Title = "Earn more than 40k per year",
        Test = (client) => client.Income > 40000,
        Positive = experienceBranch,
        Negative = new DecisionResult { Result = false }
    };

    //Decision 1
    var criminalBranch = new DecisionQuery
    {
        Title = "Have a criminal record",
        Test = (client) => client.CriminalRecord,
        Positive = new DecisionResult { Result = false },
        Negative = moneyBranch
    };

    //Decision 0
    var trunk = new DecisionQuery
    {
        Title = "Want a loan",
        Test = (client) => client.IsLoanNeeded,
        Positive = criminalBranch,
        Negative = new DecisionResult { Result = false }
    };

    return trunk;
}
public class Client
{
    public string Name { get; set; }
    public bool IsLoanNeeded { get; set; }
    public decimal Income { get; set; }
    public int YearsInJob { get; set; }
    public bool UsesCreditCard { get; set; }
    public bool CriminalRecord { get; set; }
}
public abstract class Decision
{
    public abstract void Evaluate(Client client);
}
public class DecisionQuery : Decision
{
    public string Title { get; set; }
    public Decision Positive { get; set; }
    public Decision Negative { get; set; }
    public Func<Client, bool> Test { get; set; }

    public override void Evaluate(Client client)
    {
        bool result = this.Test(client);
        string resultAsString = result ? "yes" : "no";

        Console.WriteLine($"\t- {this.Title}? {resultAsString}");

        if (result) this.Positive.Evaluate(client);
        else this.Negative.Evaluate(client);
    }
}
public class DecisionResult : Decision
{
    public bool Result { get; set; }
    public override void Evaluate(Client client)
    {
        Console.WriteLine("\r\nOFFER A LOAN: {0}", Result ? "YES" : "NO");
    }
}

}