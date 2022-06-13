FROM node:latest as build
WORKDIR /usr/src/app
COPY ["package.json", "package-lock.json*", "./"]
RUN npm install
COPY . .
RUN npm run build

# Stage 2, use the compiled app, ready for production with Nginx
FROM nginx:latest
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
RUN rm -rf /usr/share/nginx/html/*
COPY --from=build /usr/src/app/dist/ /usr/share/nginx/html
EXPOSE 80