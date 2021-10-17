FROM node:latest as build
WORKDIR /app
COPY . .

RUN npm install -f
RUN npx ng build --configuration production


FROM nginx as runtime
COPY --from=build /app/dist /usr/share/nginx/html
COPY ./default.conf /etc/nginx/conf.d/default.conf
