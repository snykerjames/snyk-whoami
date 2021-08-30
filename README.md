# snyk-whoami
Retrieve user details for the Snyk API token in use

## Standalone binaries
You can build standalone binaries for your architecture using the following command:

```bash
dotnet publish -r <RID> -c Release -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

where _\<RID\>_ is the runtime identifier for your platform as specified in https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
