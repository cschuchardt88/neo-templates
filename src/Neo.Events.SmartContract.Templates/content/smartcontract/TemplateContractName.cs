using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;

using System.ComponentModel;

namespace SmartContract;

[DisplayName("TemplateContractName")]
[ManifestExtra("Author", "TemplateContractAuthor")]
[ManifestExtra("Description", "TemplateContractDescription")]
[ManifestExtra("Email", "TemplateContractEmail")]
[ManifestExtra("Version", "<Version String Here>")]
[ContractSourceCode("https://github.com/cschuchardt88/neo-templates")]
[ContractPermission("*", "*")]
public class TemplateContractName : SmartContract
{
    [Safe]
    public static string SayHello(string name)
    {
        return "Hello, " + name;
    }

    [DisplayName("_deploy")]
    public static void OnDeployment(object data, bool update)
    {
        if (update)
            return;
    }

    public static bool Update(ByteString nefFile, string manifest)
    {
        ContractManagement.Update(nefFile, manifest);
        return true;
    }

    public static bool Destroy()
    {
        ContractManagement.Destroy();
        return true;
    }
}
