# Backend For Timetable App


# Dependencies
 - [Install Docker Client/CLI](https://www.docker.com/products/docker-desktop/)
 - [Install DBMate](https://github.com/amacneil/dbmate) we use dbmate for migrations.
 - [Install Make] we use make to shorten commands
    - [Windows](https://stackoverflow.com/questions/32127524/how-to-install-and-use-make-in-windows)
    - [Mac OS X]()
    - [Linux](https://linuxhint.com/install-make-ubuntu/)

 # Commands
- ## Make Command
    - add new command in Makefile
    - run make command e.g: `make migrate` or make `undo-migrate`

- ## Start Database
    - run `make setup-db`
    - already have a postgres instance running on your machine and do not want to start a new instance?
        - create a new database `timetable`
        - edit config file(`.env`), and update var `DATABASE_URL`
    > **Note**: it's good practice to run new migrations before creating a new one or making any edit, so always run `make migrate` after pulling changes from the repo.

- ## Make New Migration(Alter sql in migrations)
    - docs on db migrate [here](https://github.com/amacneil/dbmate)
    - RUN `dbmate new {migration-name}` e.g: `dbmate migrate add-new-field-to-student-table`
    - Edit new file created in db/migrations.
    - update the db using `make migrate`
    - Undo changes you made using `make undo-migrate`
    > **WARNING**: Do not edit any migration files after running `make migrate`, instead create a new migration and make edits.

- # No ORMS?
    We haven't fully decided yet, but we know that we might need to make complex queries in the nearest future.
    Still useful to handle migrations ourselves.
    Need to brush up your sql skills? [go-here](https://www.postgresqltutorial.com/)