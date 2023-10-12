using Neo.BlockchainToolkit;
using Neo.BlockchainToolkit.Models;
using Neo.BlockchainToolkit.SmartContract;
using Neo.VM;
using NeoTestHarness;

using NewNeoTestProject.Contracts;

namespace NewNeoTestProject;

/*
    Check file "setup.batch" for details on how to import your contract nef file.
*/

[CheckpointPath("bin/checkpoints/contract-deployed.neoxp-checkpoint")]
public class UT_TemplateContractName : IClassFixture<CheckpointFixture<UT_TemplateContractName>>
{
    private readonly CheckpointFixture _checkpointFixture;
    private readonly ExpressChain _expressChain;

    public UT_TemplateContractName(CheckpointFixture<UT_TemplateContractName> fixture)
    {
        _checkpointFixture = fixture;
        _expressChain = fixture.FindChain();
    }

    [Fact]
    public void Test_SayHello()
    {
        var settings = _expressChain.GetProtocolSettings();
        var aliceScriptHash = _expressChain.GetDefaultAccountScriptHash("alice");

        using var snapshot = _checkpointFixture.GetSnapshot();

        using var engine = new TestApplicationEngine(snapshot, settings, aliceScriptHash);

        var vmStateResult = engine.ExecuteScript<UT_ITemplateContractName>(e => e.sayHello("alice"));

        var result = engine.ResultStack.Pop();

        Assert.Equal(VMState.HALT, vmStateResult);
        Assert.Equal(VMState.HALT, engine.State);

        Assert.NotNull(result);
        Assert.False(result.IsNull);
        Assert.Equal("Hello, alice", result.GetString());
    }
}
