using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;

using System.ComponentModel;

namespace NewContractClass;

[DisplayName("TemplateContractName")]
[ManifestExtra("Author", "<Your Name Or Company Here>")]
[ManifestExtra("Description", "<Description Here>")]
[ManifestExtra("Email", "<Your Public Email Here>")]
[ManifestExtra("Version", "<Version String Here>")]
[ContractSourceCode("https://github.com/cschuchardt88/neo-templates")]
[ContractPermission("*", "*")]
public class TemplateContractName : SmartContract
{
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
