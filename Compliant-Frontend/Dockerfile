FROM node:latest as build
WORKDIR /app
COPY . . 
RUN npm install
RUN npm run build --prod

# Stage 2, use the compiled app, ready for production with Nginx
FROM nginx:latest
COPY --from=build /app/dist/ /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80