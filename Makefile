run: bin/Debug/netcoreapp3.1/SpaceManager.dll
	dotnet $^

bin/Debug/netcoreapp3.1/SpaceManager.dll:
	dotnet build

clean:
	rm -rf bin/Debug/*

clean-all:
	rm -rf bin/*
