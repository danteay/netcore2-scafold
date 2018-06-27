FROM danteay/ubuntu-netcore:latest

WORKDIR /app
ADD . /app

ENV API_KEY "asdasdasdasdasd"
ENV PORT 5001

EXPOSE $PORT
VOLUME [ ".:/app" ]
CMD [ "dotnet", "run" ]
