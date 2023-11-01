namespace Fernweh.UITests.Features.Common;

[Binding]
public class CommonSteps : Steps
{
    [StepDefinition(@"I wait (.*) seconds")]
    [StepDefinition(@"I wait (.*) second")]
    public void WeWaitXSeconds(float waitTime)
    {
        Thread.Sleep(Convert.ToInt32(waitTime * 1000f));
    }
}