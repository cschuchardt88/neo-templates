# NeoEvents.SmartContract.Templates
Neo blockchain C# templates for dotnet-new cli.

This package includes smart contracts and unit tests templates.

# List of Templates
```
Template Name                            Short Name             Language  Tags
---------------------------------------  ---------------------  --------  -----------------------------------
Neo NEP-17 Smart Contract Class          neonep17contractclass  [C#]      neo/smart contract/class/nep-17
Neo Oracle Smart Contract Project        neooracleproject       [C#]      neo/smart contract/oracle
Neo Smart Contract Class                 neocontractclass       [C#]      neo/smart contract/class/basic
Neo Smart Contract Class (with a Owner)  neocontractownerclass  [C#]      neo/smart contract/class
Neo Smart Contract Project (Basic)       neosmartcontract       [C#]      neo/smart contract/basic
Neo Smart Contract Project (Empty)       neoemptyproject        [C#]      neo/smart contract/empty
Neo Smart Contract Test Project          neosmartcontracttest   [C#]      neo/smart contract/test/xunit
```


# How to Create & Build a Project
Type in a terminal the following commands:
```
tux@PC01:~/Downloads$ dotnet new neosmartcontract -o MyContract
tux@PC01:~/Downloads$ cd MyContract
tux@PC01:~/Downloads/MyContract$ dotnet tool restore
tux@PC01:~/Downloads/MyContract$ dotnet build
```

# How to Configure a Unit Test
You will see a file called `setup.batch` in the project root directory. Open
this file and configure your `nef` filename.

## Setup.batch File
Find this line:
```bash
#contract deploy <Enter Nef Filename>
```

Remove `#` and replace `<Enter Nef Filename>` with your `nef` filename.

**Example**:
```bash
contract deploy "../Contract1/bin/sc/Contract1.nef"
```
