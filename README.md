# ICE CDR

There are binaries for each commit available in releases. Download the latest release for your OS to view the latest changes. *NOTE*: the binaries have only been tested on linux. There is no guarantee that windows or mac builds will work

## Usage

View usage
```
ice-crd --help
```

Run the program as usual to see the expected results.
```
ice-cdr
```

An optional file can be supplied. Error handling hasn't been implemented yet so the program will crash if the JSON isn't formatted correctly.
```
ice-crd --input=${HOME}/cdrs.json
```


### Running

```
dotnet run
```

### Building

```
dotnet build
```

## TODO:
- [] separate the logic into classes
    - [] create an interface with `Run` and `LogResults` methods
- [] add error handling
- [] add graceful program exits
- [] add a docker container for consistent environments between devs
