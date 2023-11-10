#pragma warning disable IDE1006

using System.ComponentModel;

namespace NewNeoTestProject.Contracts;

[Description("TemplateContractName")]
internal interface UT_ITemplateContractName
{
    /*
      Note: That method names are case sensitive.
            First character must be lowercase.
    */
    string sayHello(string name);

    void _deploy(object data, bool update);
    bool update(byte[] nefFile, string manifest);
    bool destroy();
}
