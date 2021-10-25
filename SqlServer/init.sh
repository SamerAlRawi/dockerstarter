#!/bin/bash
/opt/mssql/bin/sqlservr -c -d/var/opt/mssql/data/master.mdf -l/var/opt/mssql/data/mastlog.ldf -e/var/opt/mssql/log/errorlog -x
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Pass123@" -i ./init.sql
