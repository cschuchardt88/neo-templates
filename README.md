# neo-templates
Neo blockchain C# templates for dotnet-new

## Contract Support
- `neo` v3.6.0
- `nccs` 3.6.0
- `dotnet` v7.0

# How to Install
Type the following command in a terminal.
```
tux@PC01:~/$ dotnet new install NeoEvents.SmartContract.Templates
```

# List of Templates
```
Template Name                            Short Name             Language  Tags
---------------------------------------  ---------------------  --------  -------------------------------
Neo NEP-17 Smart Contract Class          neonep17contractclass  [C#]      neo/smart contract/class/nep-17
Neo Oracle Smart Contract Project        neooracleproject       [C#]      neo/smart contract/oracle
Neo Smart Contract Class                 neocontractclass       [C#]      neo/smart contract/class/basic
Neo Smart Contract Class (with a Owner)  neocontractownerclass  [C#]      neo/smart contract/class
Neo Smart Contract Project (Basic)       neosmartcontract       [C#]      neo/smart contract/basic
Neo Smart Contract Project (Empty)       neoemptyproject        [C#]      neo/smart contract/empty
```


# How to Create & Build a Project
Type in a terminal the following commands:
```
tux@PC01:~/Downloads$ dotnet new neosmartcontract -o MyContract
tux@PC01:~/Downloads$ cd MyContract
tux@PC01:~/Downloads/MyContract$ dotnet tool restore
tux@PC01:~/Downloads/MyContract$ dotnet build
```
