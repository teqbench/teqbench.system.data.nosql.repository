# System Data NoSql Repository

![Build Status Badge](.badges/build-status.svg) ![Build Number Badge](.badges/build-number.svg) ![Coverage](.badges/code-coverage.svg)

## Overview

Base implementation for a NoSql document repository. Override the appropriate methods to create DB if does not exist, create collection if does not exist (might not need to implement as in case of MongoDB...collection will be created upon first reference if does not exist), as well as methods to dispose of managed/unmanaged objects.

## Contents
- [Developer Environment Setup](#Developer+Environment+Setup)
- [Usage](#Usage)
- [References](#References)
- [License](#License)

## Developer Environment Setup

### General
- [Branching Strategy & Practices](https://github.com/teqbench/teqbench.docs/wiki/Branching-Strategy)

### .NET
- [General Tooling](https://github.com/teqbench/teqbench.docs/wiki/.NET-General-Tooling)
- [Configurations](https://github.com/teqbench/teqbench.docs/wiki/.NET-Configuration-Standards)
- [Coding Standards](https://github.com/teqbench/teqbench.docs/wiki/.NET-Coding-Standards)
- [Solutions](https://github.com/teqbench/teqbench.docs/wiki/.NET-Solutions)
- [Projects](https://github.com/teqbench/teqbench.docs/wiki/.NET-Projects)
- [Building, Packing & Deploying](https://github.com/teqbench/teqbench.docs/wiki/.NET-Build-Process)
- [Versioning](https://github.com/teqbench/teqbench.docs/wiki/.NET-Versioning-Standards)

## Usage

### Add NuGet Package To Project

```
dotnet add package TeqBench.System.Data.NoSql.Repository
```

### Update Source Code

> [!NOTE]
> For complete usage, see [TradingToolbox.System.Data.NoSql.MongoDB.Repository](https://github.com/teqbench/tradingtoolbox.system.data.nosql.mongodb.repository)

```csharp
/// <summary>
/// MongoDB respository operations interface.
/// </summary>
public interface IRepository<TDocument> : IRepository where TDocument : IDocument
{
}

/// <summary>
/// Base implementation for a repository. Override the appropriate methods to create DB if does not exist,
/// create collection if does not exist (might not need to implement as in case of MongoDB...collection will be created upon
/// first reference if does not exist), as well as methods to dispose of managed/unmanaged objects.
/// </summary>
public abstract class BaseRepository : IRepository
{
    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public virtual async void InitializeAsync()
    {
        // Cannot have async operations in contructor, so create an async init routine to ecapsulate 
        // async operations to be performed right have instance is created. 
        await this.CreateDatabaseIfDoesNotExistAsync();
        await this.CreateCollectionIfDoesNotExistAsync();
    }

    /// <summary>
    /// Creates the database if does not exist asynchronously.
    /// </summary>
    protected virtual async Task CreateDatabaseIfDoesNotExistAsync()
    {
        await Task.CompletedTask;
    }

    /// <summary>
    /// Creates the document collection if does not exist asynchronously.
    /// </summary>
    protected virtual async Task CreateCollectionIfDoesNotExistAsync()
    {
        await Task.CompletedTask;
    }
}
```

## Licensing

[License](https://github.com/teqbench/teqbench.docs/wiki/License)
