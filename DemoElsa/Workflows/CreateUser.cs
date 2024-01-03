using Elsa.Http;
using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Contracts;
using Elsa.Workflows.Memory;
using Elsa.Workflows.Models;

namespace DemoElsa.Workflows;

public class CreateUser : WorkflowBase
{
    protected override void Build(IWorkflowBuilder builder)
    {
        // Define a workflow variable to capture the output of the ReadLine activity.
        var account = new Variable<string>();

        // Define a simple sequential workflow:
        builder.Root = new Sequence
        {
            // Register the name variable.
            Variables = { account },

            // Setup the sequence of activities to run.
            Activities =
            {
                 new WriteLine("Please tell me your name:"),
                 new ReadLine(account),
                 new WriteLine(context => $"Nice to meet you, {account.Get(context)}!")
            }
        };

    }
}


