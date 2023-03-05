### .Net 6.0 API using a JSON flat file DB

**Prerequisites:**

- [Docker Desktop](https://www.docker.com/products/docker-desktop) (Optional)
- .Net 6

**How to setup:**

- Clone the repo locally.
- Build and run using Docker profile
- You can access the api on http://localhost:55014/swagger/index.html

**How to test:**

- The API uses Open API V3 Swagger integration. You can browse and test endpoints here: http://localhost:55014/swagger/index.html

---

**Pushing to Docker Hub Repo:**

If you want to push this to your own Docker Hub repository: you can follow these steps:

1. You may need log out first `docker logout` then log back in using `docker login`.
2. You need to include the namespace for Docker Hub to associate it with your account. The namespace is the same as your Docker Hub account name.
3. If your image does not include your account name, you can rename it by tagging it. You can do this using `docker tag SOURCE_IMAGE[:TAG] TARGET_IMAGE[:TAG]`. e.g. `docker tag dotnet-mongo-docker YOUR_DOCKERHUB_NAME/product-json-api:tag`.
4. You can then push your image by running this command: `docker push YOUR_DOCKERHUB_NAME/product-json-api:tag`.

---

**Useful command:**

- `docker build -t "YOUR_DOCKERHUB_NAME/product-json-api:tag" .` - Build the image
- `docker push YOUR_DOCKERHUB_NAME/product-json-api:tag` - Publish the image to docker hub
- `docker exec -it <containername> bash` - allows you to run commands in the containers. See [here](https://docs.docker.com/engine/reference/commandline/exec/) for more info.
- `docker tag --help` - Help info to tag an image

**Helpful Links:**

- [This project image on Docker hub](https://hub.docker.com/repository/docker/loanburger/product-json-api/general)
- [Pushing Docker images to a private registry with Docker Compose](https://medium.com/@stoyanov.veseline/pushing-docker-images-to-a-private-registry-with-docker-compose-d2797097751)

**Troubleshooting**

- For "requested access to the resource is denied" [see this solution](https://stackoverflow.com/questions/41984399/denied-requested-access-to-the-resource-is-denied-docker)
