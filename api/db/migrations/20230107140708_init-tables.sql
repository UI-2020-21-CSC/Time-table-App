-- migrate:up
create table students (
    id serial primary key,
    matric_number varchar(20) not null unique,
    name varchar(255) not null
);

-- migrate:down
drop table if exists students;
