FROM alpine

ARG portainer_user
ARG portainer_password
ARG portainer_url
ARG swapcar_stack
ARG swapcar_docker_repo
ARG swapcar_docker_network
ARG swapcar_version

ENV LANG="en_US.UTF-8" \
  LC_ALL="C.UTF-8" \
  LANGUAGE="en_US.UTF-8" \
  TERM="xterm" \
  ACTION="deploy" \
  PORTAINER_USER="$portainer_user" \
  PORTAINER_PASSWORD="$portainer_password" \
  PORTAINER_URL="$portainer_url" \
  PORTAINER_STACK_NAME="$swapcar_stack" \
  DOCKER_COMPOSE_FILE="/usr/local/bin/$swapcar_stack/docker-compose.yml" \
  PORTAINER_PRUNE="true" \
  PORTAINER_ENDPOINT="1" \
  HTTPIE_VERIFY_SSL="no" \
  VERBOSE_MODE="true" \
  DEBUG_MODE="true" \
  STRICT_MODE="false"

RUN apk --update add \
  bash \
  ca-certificates \
  httpie \
  jq \
  gettext \
  && \
  rm -rf /tmp/src && \
  rm -rf /var/cache/apk/*

COPY psu /usr/local/bin/
COPY docker-compose.yml /usr/local/bin/$swapcar_stack/docker-compose.yml

RUN sed -i -r "s/version-number/${swapcar_version}/g" /usr/local/bin/$swapcar_stack/docker-compose.yml
RUN sed -i -r "s+docker-repository+${swapcar_docker_repo}+g" /usr/local/bin/$swapcar_stack/docker-compose.yml
RUN sed -i -r "s+docker-network+${swapcar_docker_network}+g" /usr/local/bin/$swapcar_stack/docker-compose.yml

RUN chmod +x /usr/local/bin/*

ENTRYPOINT ["/usr/local/bin/psu"]
