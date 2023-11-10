using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;

using System;
using System.ComponentModel;

namespace NewNeoContractOwnerClass;

[DisplayName("TemplateContractName")]
[ManifestExtra("Author", "<Your Name Or Company Here>")]
[ManifestExtra("Description", "<Description Here>")]
[ManifestExtra("Email", "<Your Public Email Here>")]
[ManifestExtra("Version", "<Version String Here>")]
[ContractSourceCode("https://github.com/cschuchardt88/neo-templates")]
[ContractPermission("*", "*")]
public class TemplateContractName : SmartContract
{
    #region Owner

    private const byte Prefix_Owner = 0xff;

    [InitialValue("NUuJw4C4XJFzxAvSZnFTfsNoWZytmQKXQP", Neo.SmartContract.ContractParameterType.Hash160)]
    private static readonly UInt160 InitialOwner = default;

    [Safe]
    public static UInt160 GetOwner()
    {
        var currentOwner = Storage.Get(new[] { Prefix_Owner });

        if (currentOwner == null)
            return InitialOwner;

        return (UInt160)currentOwner;
    }

    private static bool IsOwner() =>
        Runtime.CheckWitness(GetOwner());

    public delegate void OnSetOwnerDelegate(UInt160 newOwner);

    [DisplayName("SetOwner")]
    public static event OnSetOwnerDelegate OnSetOwner;

    public static void SetOwner(UInt160 newOwner)
    {
        if (IsOwner() == false)
            throw new InvalidOperationException("No Authorization!");
        if (newOwner != null && newOwner.IsValid)
        {
            Storage.Put(new[] { Prefix_Owner }, newOwner);
            OnSetOwner(newOwner);
        }
    }

    #endregion

    #region Basic

    [Safe]
    public static bool Verify() => IsOwner();

    [DisplayName("_deploy")]
    public static void OnDeployment(object data, bool update)
    {
        if (update)
        {
            // Add logic for fixing contract on update
            return;
        }
        // Add logic here for 1st time deployed
    }

    public static bool Update(ByteString nefFile, string manifest)
    {
        if (IsOwner() == false)
            throw new InvalidOperationException("No Authorization!");
        ContractManagement.Update(nefFile, manifest);
        return true;
    }

    public static bool Destroy()
    {
        if (IsOwner() == false)
            throw new InvalidOperationException("No Authorization!");
        ContractManagement.Destroy();
        return true;
    }

    #endregion
}
