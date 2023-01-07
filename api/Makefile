
# Setup database
setup-db:
	docker run --name timetabledb -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgrespw -e POSTGRES_DB=timetable -d postgres:latest

migrate:
	dbmate up

undo-migrate:
	dbmate down
