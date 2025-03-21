# ChecklistAPI

### Manual commands
```sh
# build the image
docker build -t checklist-api .
# run the container
docker run -p 8080:8080 -d --restart unless-stopped checklist-api
# docker compose instead
docker-compose -f docker-compose.debug.yml up --build -d
```

## Documentation
(only work outside docker for now)
https://localhost:7092/swagger
https://localhost:7092/openapi/v1.json


## Notes
* the secret sauce for converting .NET PascalCase to postgresql snake_case using dapper is adding the following to `Program.cs`:
	```csharp
	Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
	```


