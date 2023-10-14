namespace Fernweh.UITests.Features.Common;

[Binding]
public class CommonSteps : Steps
{
    [StepDefinition(@"we wait (.*) seconds")]
    [StepDefinition(@"we wait (.*) second")]
    public void WeWaitXSeconds(float waitTime)
    {
        Thread.Sleep(Convert.ToInt32(waitTime * 1000f));
    }
}