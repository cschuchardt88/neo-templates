using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;

using System;
using System.ComponentModel;
using System.Numerics;

namespace NewNep17ContractClass;

[DisplayName("TemplateContractName")]
[ManifestExtra("Author", "<Your Name Or Company Here>")]
[ManifestExtra("Description", "<Description Here>")]
[ManifestExtra("Email", "<Your Public Email Here>")]
[ManifestExtra("Version", "<Version String Here>")]
[ContractSourceCode("https://github.com/cschuchardt88/neo-templates")]
[ContractPermission("*", "*")]
[SupportedStandards("NEP-17")]
public class TemplateContractName : Nep17Token
{
    #region Owner

    private const byte Prefix_Owner = 0x02;

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

    #region Minter

    private const byte Prefix_Minter = 0x03;

    [InitialValue("NUuJw4C4XJFzxAvSZnFTfsNoWZytmQKXQP", Neo.SmartContract.ContractParameterType.Hash160)]
    private static readonly UInt160 InitialMinter = default;

    [Safe]
    public static UInt160 GetMinter()
    {
        var currentMinter = Storage.Get(new[] { Prefix_Minter });

        if (currentMinter == null)
            return InitialMinter;

        return (UInt160)currentMinter;
    }

    private static bool IsMinter() =>
        Runtime.CheckWitness(GetMinter());

    public delegate void OnSetMinterDelegate(UInt160 newMinter);

    [DisplayName("SetMinter")]
    public static event OnSetMinterDelegate OnSetMinter;

    public static void SetMinter(UInt160 newMinter)
    {
        if (IsOwner() == false)
            throw new InvalidOperationException("No Authorization!");
        if (newMinter != null && newMinter.IsValid)
        {
            Storage.Put(new[] { Prefix_Minter }, newMinter);
            OnSetMinter(newMinter);
        }
    }

    public static new void Mint(UInt160 to, BigInteger amount)
    {
        if (IsOwner() == false && IsMinter() == false)
            throw new InvalidOperationException("No Authorization!");
        Nep17Token.Mint(to, amount);
    }

    #endregion

    #region NEP17

    [Safe]
    public override byte Decimals() => 8;

    [Safe]
    public override string Symbol() => "EXAMPLE";

    public static new void Burn(UInt160 account, BigInteger amount)
    {
        if (IsOwner() == false && IsMinter() == false)
            throw new InvalidOperationException("No Authorization!");
        Nep17Token.Burn(account, amount);
    }

    #endregion

    #region Payment

    public static bool Withdraw(UInt160 to, BigInteger amount)
    {
        if (IsOwner() == false)
            throw new InvalidOperationException("No Authorization!");
        if (amount <= 0)
            return false;
        // TODO: Add logic
        return true;
    }

    public static void OnNEP17Payment(UInt160 from, BigInteger amount, object data)
    {
        // TODO: Add logic
    }

    #endregion

    #region Basic

    [Safe]
    public static bool Verify() => IsOwner();

    public static bool Update(ByteString nefFile, string manifest)
    {
        if (IsOwner() == false)
            throw new InvalidOperationException("No Authorization!");
        ContractManagement.Update(nefFile, manifest);
        return true;
    }

    #endregion
}
