# stage 1
FROM node:14.18.1-alpine3.11 as node
WORKDIR /app
COPY . .

ARG BUILD_ENVIRONMENT

RUN npm install
RUN npm run $BUILD_ENVIRONMENT

# stage 2
FROM nginx:alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY security-headers.conf /etc/nginx/security-headers.conf
COPY --from=node /app/dist /usr/share/nginx/html
