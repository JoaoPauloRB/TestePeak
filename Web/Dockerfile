FROM nginx:alpine as final
WORKDIR /usr/share/nginx/html
COPY src/ .
COPY ./nginx.conf /etc/nginx/nginx.conf