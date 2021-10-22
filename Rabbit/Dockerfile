FROM rabbitmq:3.9.8-management-alpine

# ENV RABBITMQ_USER guest
# ENV RABBITMQ_PASSWORD guest

ADD rabbitmq.config /etc/rabbitmq/
ADD definitions.json /etc/rabbitmq/
RUN chown rabbitmq:rabbitmq /etc/rabbitmq/rabbitmq.config /etc/rabbitmq/definitions.json

CMD ["rabbitmq-server"]

# EXPOSE 15672

# RUN rabbitmqctl add_user defaultuser defaultuser
# RUN rabbitmqctl set_user_tags username administrator
# RUN rabbitmqctl set_permissions -p / defaultuser ".*" ".*" ".*"
