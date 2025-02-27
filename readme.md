# ChecklistAPI


## Development server
just F5 it bro:
https://localhost:7092/list/e4d81920-987c-495f-85bd-2847951dbef0 -- any valid guid will do for now
docker:
http://localhost:8080/list/e4d81920-987c-495f-85bd-2847951dbef0 -- any valid guid will do for now

## Docker
```sh
# build the image
docker build -t checklist-api .
# run the container
docker run -p 8080:8080 -d --restart unless-stopped checklist-api
```

## Documentation
https://localhost:7092/swagger
https://localhost:7092/openapi/v1.json


## TODO
- finish dockerization
	- add to f5 config
	- get swagger/openapi working in docker
- EF vs dbup?
- monorepo setup
