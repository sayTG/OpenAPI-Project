# Stage 1: Build an Angular Docker Image
FROM node as build
WORKDIR /apps
COPY . .
RUN npm install
COPY . /apps
ARG configuration=production
RUN npm run build — — outputPath=./dist/out — configuration $configuration

# Stage 2, use the compiled app, ready for production with Nginx
FROM nginx:alpine
COPY --from=build /usr/src/app/dist /usr/share/nginx/html
WORKDIR /usr/share/nginx/html
# Remove default nginx static assets
RUN rm -rf ./*
COPY --from=build /app/build .
ENTRYPOINT ["nginx", "-g", "daemon off;"]