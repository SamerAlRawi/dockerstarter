FROM mcr.microsoft.com/mssql/server:2019-CU13-ubuntu-20.04

ENV SA_PASSWORD=Pass123@
ENV ACCEPT_EULA=Y

WORKDIR /init

RUN mkdir /var/opt/mssql/data
RUN chown -R mssql /var/opt/mssql/data

USER root

COPY ./init.sql ./init.sql
COPY ./init.sh ./init.sh
RUN chmod +x ./init.sql
RUN chmod +x ./init.sh
 
EXPOSE 1433:1433

ENTRYPOINT [ "/init/init.sh" ]
