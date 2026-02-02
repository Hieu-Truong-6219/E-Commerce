#!/bin/bash
docker compose down

docker compose build && docker compose up || exit 1

docker image prune --force
