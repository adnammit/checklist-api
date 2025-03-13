# ChecklistAPI

## Running in Docker
just F5 it bro! current state of affairs:
- Docker .NET Launch task: gives you debugging, random port will be assigned
	{base_url}/list/e4d81920-987c-495f-85bd-2847951dbef0
- Docker .NET Launch (Compose) task: no debugging, but you get a consistent port
	http://localhost:5064/list/e4d81920-987c-495f-85bd-2847951dbef0
- note that any valid guid will do for now

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


## TODO
- finish dockerization
	- set up monorepo
	- add to f5 config
	- get swagger/openapi working in docker
	- hot reloading??
- EF vs dbup?
- monorepo setup
